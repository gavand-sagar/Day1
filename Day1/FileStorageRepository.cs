
using System.Text.Json;

namespace Day1
{
    public class FileStorageRepository<T> : IRepository<T>
    {
        string fileLocation = "C:\\Users\\Sagar\\Desktop\\data.txt";
        public IEnumerable<T> GetAll()
        {
            string content = File.ReadAllText(fileLocation);
            return JsonSerializer.Deserialize<IEnumerable<T>>(content);
        }

        public void Insert(T entity)
        {
            var previousData = GetAll();
            var newData = previousData.ToList();
            newData.Add(entity);
            string content = JsonSerializer.Serialize(newData);
            File.WriteAllText(fileLocation,content);
        }
    }
}
