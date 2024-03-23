import requests
from bs4 import BeautifulSoup

import db

URL = 'https://www.flagistrany.ru'


def get_html(url):
    response = requests.get(url)
    return response


def get_soup(urn):
    html = get_html(f"{URL}{urn}").text.replace(u'\xa0', ' ')
    soup = BeautifulSoup(html, 'html.parser')
    return soup


def scrap_all_flags():
    soup = get_soup("/azbuka")
    ul = soup.find("ul", {"class": "flag-grid"})
    li = ul.find_all("li")
    for item in li:
        flag_tag = item.find("a")
        name = flag_tag.find("span").text.strip()
        href = flag_tag.get("href")
        get_flag_info(href, name)


def download_flag(url, filename):
    r = requests.get(f'{URL}{url}', stream=True)
    if r.status_code == 200:
        with open(f'countries/{filename}.png', 'wb') as f:
            for chunk in r:
                f.write(chunk)


def get_flag_info(urn, name):
    translation = {
        "Суверенное государство": "sovereign",
        "Коды стран": "codes",
        "Столица": "capital",
        "Континент": "continent",
        "Член": "member",
        "Население": "population",
        "Область": "area",
        "Валюта": "currency",
        "Телефонный код города": "phone_code",
        "Национальный домен": "domain",
        "Высшая точка": "highest_point",
        "Низшая точка": "lowest_point",
        "ВВП на душу населения": "gdp",
        "Официальное название": "official_name"
    }

    soup = get_soup(urn)
    data = {}
    img_src = soup.find("picture").find("img").get("src").strip()

    row = soup.find("tbody").find_all("tr")
    keys = list(map(lambda x: x.find("th").text, row))
    values = list(map(lambda x: x.find("td").text, row))
    print(name)
    try:
        data = {translation[keys[i].replace(u'\xa0', ' ')]: values[i].replace(u'\xa0', ' ') for i in range(len(keys))}
    except IndexError:
        print(name, "ОШИБКА")
    country = db.Country(country_name=name, image_url=f'countries/{name}')
    if data:
        country.country_info = db.CountryInfo(**data)
        country.country_info.save()
    country.save()
    download_flag(img_src, name)


if __name__ == "__main__":
    scrap_all_flags()
