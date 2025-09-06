namespace Day1
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void Insert(T entity);
        T Get(Predicate<T> predicate);

    }
}
