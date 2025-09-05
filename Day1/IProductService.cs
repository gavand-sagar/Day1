namespace Day1
{
    public interface IProductService
    {
        public List<Product> Getall(); // sql // mongoDB
        public Product GetOne(int id);
        public bool DeleteOne(int id);
        public Product Create(Product product);
    }
}
