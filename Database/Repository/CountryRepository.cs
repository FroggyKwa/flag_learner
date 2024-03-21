using FlagLearner.Database.Entities;
using FlagLearner.Database.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlagLearner.Database.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly CountriesContext _db;

        public CountryRepository(CountriesContext db)
        {
            _db = db;
        }

        public Country Create(Country item)
        {
            return _db.Add(item).Entity;
        }

        public Country? Delete(int id)
        {
            Country? item = GetItem(id);
            if (item == null)
                return null;
            return _db.Remove(item).Entity;
        }

        public IEnumerable<Country> GetAll()
        {
            return _db.Countries.Select(item => item).ToList();
        }

        public Country? GetItem(int id)
        {
            return _db.Countries
                .Include(c => c.CountryInfo)
                .Include(c => c.Lines)
                .Include(c => c.Colors)
                .FirstOrDefault(item => item.Id == id);
        }

        public void Save()
        {
            _db.SaveChangesAsync();
        }

        public Country? Update(Country item)
        {
            return _db.Countries.Update(item).Entity;
        }
    }
}
