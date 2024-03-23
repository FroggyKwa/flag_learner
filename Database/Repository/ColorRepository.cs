using FlagLearner.Database.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Color = FlagLearner.Database.Entities.Color;

namespace FlagLearner.Database.Repository
{
    public class ColorRepository : IColorRepository
    {
        private readonly CountriesContext _db;

        public ColorRepository(CountriesContext db)
        {
            _db = db;
        }

        public Color Create(Color item)
        {
            return _db.Add(item).Entity;
        }

        public Color? Delete(int id)
        {
            Color? item = GetItem(id);
            if (item == null)
                return null;
            return _db.Remove(item).Entity;
        }

        public List<Color> GetAll()
        {
            return _db.Colors
                .Include(color => color.Country)
                .Select(item => item).ToList();
        }

        public Color? GetItem(int id)
        {
            return _db.Colors.FirstOrDefault(item => item.Id == id);
        }

        public void Save()
        {
            _db.SaveChangesAsync();
        }

        public Color? Update(Color item)
        {
            return _db.Colors.Update(item).Entity;
        }
    }
}