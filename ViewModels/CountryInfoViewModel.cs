using FlagLearner.Database;
using FlagLearner.Database.Entities;
using FlagLearner.Database.Repository;

namespace FlagLearner.ViewModels
{
    public class CountryInfoViewModel : IViewModelBase
    {
        public Country selectedCountry = null!;
        public CountryInfo countryInfo = null!;


        public CountryInfoViewModel(Country country)
        { 
            selectedCountry = country;
            countryInfo = country.CountryInfo;
        }
    }
}
