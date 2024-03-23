import peewee
from peewee import SqliteDatabase

db = SqliteDatabase('countries.db')


class CountryInfo(peewee.Model):
    codes = peewee.CharField(null=True)
    capital = peewee.CharField(max_length=32, null=True)
    continent = peewee.CharField(max_length=32, null=True)
    sovereign = peewee.CharField(max_length=3, null=True)
    member = peewee.CharField(null=True)
    population = peewee.IntegerField(null=True)
    area = peewee.IntegerField(null=True)
    currency = peewee.CharField(null=True)
    phone_code = peewee.CharField(null=True)
    domain = peewee.CharField(null=True)
    gdp = peewee.CharField(null=True)
    highest_point = peewee.CharField(null=True)
    lowest_point = peewee.CharField(null=True)

    class Meta:
        database = db


class Country(peewee.Model):
    country_name = peewee.CharField(max_length=64)
    country_info = peewee.ForeignKeyField(CountryInfo, backref='country', null=True)
    image_url = peewee.CharField()

    class Meta:
        database = db


class Color(peewee.Model):
    color_name = peewee.CharField(max_length=16)
    country = peewee.ForeignKeyField(Country, backref='color')

    class Meta:
        database = db


class Line(peewee.Model):
    line = peewee.CharField(max_length=16)
    country = peewee.ForeignKeyField(Country, backref='line', null=True)

    class Meta:
        database = db


def get_country_by_name(country_name):
    return Country.get(Country.country_name == country_name)


db.create_tables([Country, CountryInfo, Color, Line])