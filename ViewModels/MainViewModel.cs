using FlagLearner.Database;
using FlagLearner.Database.Entities;
using FlagLearner.Database.Repository;
using FlagLearner.Views.Common;

namespace FlagLearner.ViewModels
{
    public class MainViewModel
    {
        private readonly CountriesContext _db = null!;
        private readonly CountryRepository _countryRepository = null!;
        public List<Country> countries { get; } = null!;
        public int selectedCountryId { get; set; }
        public Country? selectedCountry { 
            get => _countryRepository.GetItem(selectedCountryId); }

        public MainViewModel()
        {
            _db = new CountriesContext();
            _countryRepository = new CountryRepository(_db); 
            countries = _countryRepository.queryBuilder.GetAll().Build();
        }
    }
}
