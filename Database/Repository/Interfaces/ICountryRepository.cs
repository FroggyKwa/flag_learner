using FlagLearner.Database.Entities;

namespace FlagLearner.Database.Repository.Interfaces
{
    public interface ICountryRepository: IRepository<Country> {
        public Country? GetItemByName(string name);
    }
}
