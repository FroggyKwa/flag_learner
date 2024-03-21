using FlagLearner.Database;
using FlagLearner.Database.Entities;
using FlagLearner.Database.Repository;

namespace FlagLearner.ViewModels
{
    public class MainViewModel : IViewModelBase
    {
        public List<Country> countries { get; } = null!;
        public int selectedCountryId { get; set; }
        public Country? selectedCountry {
            get => _countryRepository.GetItem(selectedCountryId); }

        

        public MainViewModel()
        {
            countries = _countryRepository.queryBuilder.GetAll().Build();
        }

        public CountryInfoViewModel? CreateViewModel()
        {
            if (selectedCountry != null)
                return new CountryInfoViewModel(selectedCountry!);
            return null;
        }

    }
}
