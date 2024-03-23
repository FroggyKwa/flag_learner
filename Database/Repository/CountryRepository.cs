using FlagLearner.Database.Converters;
using FlagLearner.Database.Entities;
using FlagLearner.Database.Repository.Interfaces;
using FlagLearner.Helpers;
using Microsoft.EntityFrameworkCore;

using static FlagLearner.Database.Converters.CountryConverter;

namespace FlagLearner.Database.Repository
{
    public class CountryRepository : ICountryRepository
    {

        private readonly CountriesContext _db;

        public CountryRepository(CountriesContext db)
        {
            _db = db;
        }

        public DomainCountryModel Create(DomainCountryModel item)
        {
            return _db.Add(item.ToModel()).Entity.ToDomain();
        }

        public DomainCountryModel? Delete(int id)
        {
            DomainCountryModel? item = GetItem(id);
            if (item == null)
                return null;
            return _db.Remove(item.ToModel()).Entity.ToDomain();
        }

        public List<DomainCountryModel> GetAll()
        {
            return _db.Countries
                .Include(c => c.Lines)
                .Include(c => c.Colors)
                .Select(item => item.ToDomain())
                .ToList();
        }

        public DomainCountryModel? GetItem(int id)
        {
            return _db.Countries
                .Include(c => c.CountryInfo)
                .Include(c => c.Lines)
                .Include(c => c.Colors)
                .FirstOrDefault(item => item.Id == id)?.ToDomain();
        }

        public void Save()
        {
            _db.SaveChangesAsync();
        }

        public DomainCountryModel? Update(DomainCountryModel item)
        {
            return _db.Countries.Update(item.ToModel()).Entity.ToDomain();
        }

        public DomainCountryModel? GetItemByName(string name)
        {
            return _db.Countries.FirstOrDefault(item => item.CountryName == name)?.ToDomain();
        }

        public List<DomainCountryModel> WithLines(List<string> lines)
        {
            return GetAll()
                .Where(item => item.Lines
                .Intersect(lines).Any())
                .ToList();
        }

        public List<DomainCountryModel> WithColors(List<string> colors)
        {
            return GetAll()
            .Where(item => item.Colors
                .Intersect(colors).Any())
                .ToList();
        }
    }
}
