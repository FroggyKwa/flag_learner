namespace Database.Entities
{
    public class Color
    {
        public string ColorName { get; set; }
        public Country Country { get; set; }

        public Color(Country country, string colorName)
        {
            Country = country;
            ColorName = colorName;
        }
    }
}
