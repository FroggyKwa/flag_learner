import os

from PIL import Image
from PIL import ImageChops
import numpy as np
from db import Color, Country, Line, get_country_by_name


def pixelate(image, pixel_size):
    image = image.resize(
        (image.size[0] // pixel_size, image.size[1] // pixel_size),
        Image.NEAREST
    )
    image = image.resize(
        (image.size[0] * pixel_size, image.size[1] * pixel_size),
        Image.NEAREST
    )
    return image.convert("RGB")


def substitute_pixel_rows(r1: list[tuple], r2: list[tuple]):
    res = [(r1[i][0] - r2[i][0], r1[i][1] - r2[i][1], r1[i][2] - r2[i][2]) for i in range(len(r1))]
    return res


def check_diagonal(img):
    diff = ImageChops.difference(img, pixelate(img, 40))
    diff_pixels = diff.getdata()
    cnt = list(diff_pixels).count((0, 0, 0))
    if cnt / len(diff_pixels) <= 0.95:
        return "diagonal"


def get_image_colors(img: Image):
    image = img.convert("RGB")
    w, h = image.size
    colors = get_discrete_color_value(img.getcolors(), w, h)
    return colors


def get_discrete_color_value(colors, w, h):
    DEFAULT_COLORS = {(255, 255, 255): "white",
                      (255, 0, 0): 'red',
                      (0, 255, 0): 'green',
                      (0, 0, 255): 'blue',
                      (255, 255, 0): 'yellow',
                      (255, 0, 255): 'purple',
                      (0, 255, 255): 'light blue'}
    image_colors = set()
    for count, color in colors:
        if count / (w * h) >= 0.007:
            if color != (0, 0, 0):
                color_diff = [tuple(np.abs(np.array(color) - np.array(key))) for key in DEFAULT_COLORS]
                image_colors.add(tuple(DEFAULT_COLORS.values())[color_diff.index(min(color_diff))])
            else:
                image_colors.add('black')
    return image_colors


def analyze_color_row(row):
    return [(row.count(color), color) for color in set(row) if row.count(color) / len(row) >= 0.25]


def check_equality_rows_cols(img, direction, width, height):
    pixels = []
    if direction == "horizontal":
        pixels = [list(img.getdata())[i * width:(i + 1) * width] for i in range(height)]
    elif direction == "vertical":
        pixels = [list(img.rotate(90, expand=True).getdata())[i * height:(i + 1) * height] for i in range(width)]

    colors = set()
    for row in pixels:
        new_row = get_discrete_color_value(analyze_color_row(row), len(row), 1)
        if colors != set() and new_row - colors:
            return direction
        colors.update(new_row)


def check_pattern(filename: str):
    print('Проверяю паттерн')
    img = Image.open(f"countries/{filename}").convert("RGB")
    width, height = img.size
    print('Проверяю горизонтальное преобладание линий')
    horizontal = check_equality_rows_cols(img, "horizontal", width, height)
    print('Проверяю вертикальное преобладание линий')
    vertical = check_equality_rows_cols(img, "vertical", width, height)
    print('Проверяю диагональное преобладание линий / сложный орнамент')
    diagonal = check_diagonal(img)
    print('Считаю цвета изображения')
    colors = get_image_colors(img)
    return [flag for flag in [horizontal, vertical, diagonal] if flag], colors


def get_flags_info():
    for filename in os.listdir("countries"):
        if filename.endswith("png"):
            country_name = filename.strip('.png')
            print(country_name)
            country = get_country_by_name(country_name)
            lines, colors = check_pattern(filename)
            for line in lines:
                Line(country=country, line=line).save()
            for color in colors:
                Color(country=country, color_name=color).save()
            print('-' * 20)


if __name__ == '__main__':
    get_flags_info()