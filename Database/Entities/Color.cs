namespace FlagLearner.Database.Entities
{
    public partial class Color
    {
        public long Id { get; set; }
        public string ColorName { get; set; } = null!;
        public long CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;

        public override string ToString()
        {
            return ColorName;
        }
    }
}
