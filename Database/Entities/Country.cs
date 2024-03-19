namespace FlagLearner.Database.Entities
{
    public partial class Country
    {
        public Country()
        {
            Colors = new HashSet<Color>();
            Lines = new HashSet<Line>();
        }

        public long Id { get; set; }
        public string CountryName { get; set; } = null!;
        public long? CountryInfoId { get; set; }
        public string ImageUrl { get; set; } = null!;

        public virtual Countryinfo? CountryInfo { get; set; }
        public virtual ICollection<Color> Colors { get; set; }
        public virtual ICollection<Line> Lines { get; set; }
    }
}
