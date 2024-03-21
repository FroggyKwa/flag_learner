using FlagLearner.Database.Repository;
using FlagLearner.Database;

namespace FlagLearner.ViewModels
{
    public abstract class IViewModelBase
    {
        protected static CountriesContext _db;
        protected static CountryRepository _countryRepository;

        public IViewModelBase()
        {
            _db = new CountriesContext();
            _countryRepository = new(_db);
        }
    }
}
