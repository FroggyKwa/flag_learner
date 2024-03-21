namespace FlagLearner.Database.Entities
{
    public partial class CountryInfo
    {
        public CountryInfo()
        {
            Countries = new HashSet<Country>();
        }

        public long Id { get; set; }
        public string? Codes { get; set; }
        public string? Capital { get; set; }
        public string? Continent { get; set; }
        public string? Sovereign { get; set; }
        public string? Member { get; set; }
        public long? Population { get; set; }
        public long? Area { get; set; }
        public string? Currency { get; set; }
        public string? PhoneCode { get; set; }
        public string? Domain { get; set; }
        public string? Gdp { get; set; }
        public string? HighestPoint { get; set; }
        public string? LowestPoint { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}
