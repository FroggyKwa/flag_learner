using FlagLearner.Database.Entities;

namespace FlagLearner.Database.Converters
{

    public static class CountryConverter
    {
        public class DomainCountryModel
        {
            public long Id;
            public long? CountryInfoId;
            public string CountryName;
            public string ImageUrl;
            public CountryInfo CountryInfo;
            public List<string> Colors;
            public List<string> Lines;

            public DomainCountryModel(
                long id,
                long? countryInfoId,
                string countryName,
                string imageUrl,
                CountryInfo countryInfo,
                List<string> colors,
                List<string> lines)
            {
                Id = id;
                CountryInfoId = countryInfoId;
                CountryName = countryName;
                ImageUrl = imageUrl;
                CountryInfo = countryInfo;
                Colors = colors;
                Lines = lines;
            }

            public override string ToString()
            {
                return CountryName;
            }

        }
        public static DomainCountryModel ToDomain(this Country country)
        {
            return new DomainCountryModel(id: country.Id,
                countryInfoId: country.CountryInfoId,
                countryName: country.CountryName,
                imageUrl: country.ImageUrl,
                countryInfo: country.CountryInfo,
                colors: country.Colors.Select(item => item.ColorName).ToList(),
                lines: country.Lines.Select(item => item.Name).ToList());
        }

        public static Country ToModel(this DomainCountryModel country)
        {
            return new Country
            {
                Id = country.Id,
                CountryInfoId = country.CountryInfoId,
                CountryName = country.CountryName,
                ImageUrl = country.ImageUrl,
                CountryInfo = country.CountryInfo,
            };
        }
    }
}
