using FlagLearner.Database.Entities;
using FlagLearner.Database.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlagLearner.Database.Repository
{
    public class CountryRepository : ICountryRepository
    {
        public class QueryBuilder
        {
            private readonly CountriesContext _db;
            private IQueryable<Country> _query = null!;

            public QueryBuilder(CountriesContext db)
            {
                _db = db;
            }

            public List<Country> Build()
            {
                return _query.ToList();
            }

            public QueryBuilder GetAll()
            {
                _query = _db.Countries.Select(item => item);
                return this;
            }

            public QueryBuilder WithColors()
            {
                _query = _query.Include(c => c.Colors);
                return this;
            }

            public QueryBuilder WithLines()
            {
                _query = _query.Include(c => c.Lines);
                return this;
            }
        }

        private readonly CountriesContext _db;
        public QueryBuilder queryBuilder;

        public CountryRepository(CountriesContext db)
        {
            _db = db;
            queryBuilder = new QueryBuilder(db);
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

        public List<Country> GetAll()
        {
            return queryBuilder.GetAll().Build();
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

        public Country? GetItemByName(string name)
        {
            return _db.Countries.FirstOrDefault(item => item.CountryName == name);
        }
    }
}
