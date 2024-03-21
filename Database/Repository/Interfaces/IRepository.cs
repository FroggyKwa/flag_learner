namespace FlagLearner.Database.Repository.Interfaces
{
    public interface IRepository <T> where T : class
    {
        List<T> GetAll();
        T? GetItem(int id);
        T Create(T item);
        T? Update(T item);
        T? Delete(int id);
        void Save();
    }
}