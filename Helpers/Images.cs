using FlagLearner.Database.Entities;

namespace FlagLearner.Helpers
{
    public class Images
    {
        static public Image LoadImageByObj(Country country)
        {
            return Image.FromFile($"../../../{country.ImageUrl}");
        }
    }
}
