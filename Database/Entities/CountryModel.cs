namespace Database.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }

        public string ImageUrl { get; set; }

        public CountryInfo CountryInfo { get; set; }

        public Country(CountryInfo countryInfo, string imageUrl, string countryName)
        {
            CountryInfo = countryInfo;
            ImageUrl = imageUrl;
            CountryName = countryName;
        }
    }
}
