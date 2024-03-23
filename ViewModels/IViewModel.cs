using FlagLearner.Database.Repository;
using FlagLearner.Database;

namespace FlagLearner.ViewModels
{
    public abstract class IViewModelBase
    {
        protected static CountriesContext _db = null!;
        protected static CountryRepository _countryRepository = null!;

        public IViewModelBase()
        {
            _db = new CountriesContext();
            _countryRepository = new(_db);
        }
    }
}
