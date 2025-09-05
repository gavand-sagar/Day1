
namespace Day1
{
    // storage in RAM / in List<T>
    public class InMemoryRepository<T> : IRepository<T>
    {
        private readonly List<T> _list;

        public InMemoryRepository()
        {
            this._list = new List<T>();
        }

        public void Insert(T obj)
        {
            this._list.Add(obj);
        }

        public IEnumerable<T> GetAll()
        {
            return _list.AsEnumerable();
        }

      
    }
}
