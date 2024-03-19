namespace Database.Entities
{
    public class Line
    {
        public string line { get; set; }
        public Country Country { get; set; }

        public Line(Country country, string line_val)
        {
            Country = country;
            line = line_val;
        }
    }
}
