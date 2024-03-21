using FlagLearner.Database.Entities;

namespace FlagLearner.Views.Common
{
    public class Images
    {
        static public Image LoadImageByObj(Country country)
        {
            return Image.FromFile($"../../../{country.ImageUrl}");
        }
    }
}
