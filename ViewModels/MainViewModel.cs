﻿using FlagLearner.Database.Repository;
using FlagLearner.Helpers;
using static FlagLearner.Database.Converters.CountryConverter;
using static FlagLearner.Helpers.FilterCompute;

namespace FlagLearner.ViewModels
{
    public class MainViewModel : IViewModelBase
    {
        private LineRepository _lineRepository = null!;
        public List<DomainCountryModel> countries { get; set; } = null!;
        public int selectedCountryId { get; set; }

        public int selectedListIndex { get; set; }
        public DomainCountryModel? selectedCountry {
            get => _countryRepository
                .GetItem(
                (int)countries[selectedListIndex].Id);
        }


        public MainViewModel()
        {
            countries = new();
            _lineRepository = new LineRepository(_db);
        }

        public CountryInfoViewModel? CreateViewModel()
        {
            if (selectedCountry != null)
                return new CountryInfoViewModel(selectedCountry!);
            return null;
        }

        public List<DomainCountryModel> LoadCountries(Dictionary<string, List<string>?> filters)
        {
            var withLines = _countryRepository.WithLines(filters["lines"]!);
            var withColors = _countryRepository.WithColors(filters["colors"]!);

            if (!withColors.Any() && !withLines.Any())
            {
                countries.Clear();
                countries = _countryRepository.GetAll();
            }
            else
                countries = FilterCompute.IntersectNonEmpty(new List<List<DomainCountryModel>>() { withLines, withColors });
            return countries;
        }
    }
}
