using static FlagLearner.Database.Converters.CountryConverter;

namespace FlagLearner.Helpers
{
    public class CountryListComparer : IEqualityComparer<DomainCountryModel>
    {
        public bool Equals(DomainCountryModel? x, DomainCountryModel? y)
        {
            if (ReferenceEquals(x, y))
                return true;
            if (x == null || y == null)
                return false;
            return x.CountryName == y.CountryName;
        }

        public int GetHashCode(DomainCountryModel obj)
        {
            return obj.CountryName.GetHashCode();
        }
    }
    public static class FilterCompute
    {
        public static List<DomainCountryModel> IntersectLists(List<List<DomainCountryModel>> lists)
        {
            // Filter out empty lists and perform intersection
            return lists
                .Where(l => l.Any()) // Keep only non-empty lists
                .Aggregate((l1, l2) => l1.Intersect(l2, new CountryListComparer()).ToList());
        }
    }
}
