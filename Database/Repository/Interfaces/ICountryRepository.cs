using FlagLearner.Database.Entities;
using static FlagLearner.Database.Converters.CountryConverter;

namespace FlagLearner.Database.Repository.Interfaces
{
    public interface ICountryRepository: IRepository<DomainCountryModel> {
        public DomainCountryModel? GetItemByName(string name);
        public List<DomainCountryModel> WithLines(List<string> lines);
        public List<DomainCountryModel> WithColors(List<string> colors);
    }
}
