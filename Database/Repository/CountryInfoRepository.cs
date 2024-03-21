using FlagLearner.Database.Entities;
using FlagLearner.Database.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlagLearner.Database.Repository
{
    public class CountryInfoRepository : ICountryInfoRepository
    {
        private readonly CountriesContext _db;

        public CountryInfoRepository(CountriesContext db)
        {
            _db = db;
        }

        public CountryInfo Create(CountryInfo item)
        {
            return _db.Add(item).Entity;
        }

        public CountryInfo? Delete(int id)
        {
            CountryInfo? item = GetItem(id);
            if (item == null)
                return null;
            return _db.Remove(item).Entity;
        }

        public IEnumerable<CountryInfo> GetAll()
        {
            return _db.CountryInfos.Select(item => item);
        }

        public CountryInfo? GetItem(int id)
        {
            return _db.CountryInfos
                .Include(c => c.Countries)
                .FirstOrDefault(item => item.Id == id);
        }

        public void Save()
        {
            _db.SaveChangesAsync();
        }

        public CountryInfo? Update(CountryInfo item)
        {
            return _db.CountryInfos.Update(item).Entity;
        }
    }
}
