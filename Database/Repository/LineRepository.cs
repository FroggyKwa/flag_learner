using FlagLearner.Database.Entities;
using FlagLearner.Database.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlagLearner.Database.Repository
{
    public class LineRepository : ILineRepository
    {
        private readonly CountriesContext _db;

        public LineRepository(CountriesContext db)
        {
            _db = db;
        }

        public Line Create(Line item)
        {
            return _db.Add(item).Entity;
        }

        public Line? Delete(int id)
        {
            Line? item = GetItem(id);
            if (item == null)
                return null;
            return _db.Remove(item).Entity;
        }

        public List<Line> GetAll()
        {
            return _db.Lines
                .Include(line => line.Country)
                .Select(item => item).ToList();
        }

        public Line? GetItem(int id)
        {
            return _db.Lines.FirstOrDefault(item => item.Id == id);
        }

        public void Save()
        {
            _db.SaveChangesAsync();
        }

        public Line? Update(Line item)
        {
            return _db.Lines.Update(item).Entity;
        }
    }
}