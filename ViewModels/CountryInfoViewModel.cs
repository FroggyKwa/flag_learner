using FlagLearner.Database;
using FlagLearner.Database.Entities;
using FlagLearner.Database.Repository;
using static FlagLearner.Database.Converters.CountryConverter;

namespace FlagLearner.ViewModels
{
    public class CountryInfoViewModel : IViewModelBase
    {
        public DomainCountryModel selectedCountry = null!;
        public CountryInfo countryInfo = null!;


        public CountryInfoViewModel(DomainCountryModel country)
        { 
            selectedCountry = country;
            countryInfo = country.CountryInfo;
        }
    }
}
