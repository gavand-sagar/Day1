
namespace Day1
{
    public class ProductServiceSoftDelete : IProductService
    {

        int lastId = 0;
        List<Product> products = new List<Product>();

        public List<Product> Getall()
        {
            return products;
        }

        public Product GetOne(int id)
        {
            return products.Find(x => x.Id == id);
        }

        public bool DeleteOne(int id)
        {
            foreach (Product p in products)
            {
                if(p.Id == id)
                {
                    p.Name = "------DELETED---------";
                }
            }
            return true;
        }

        public Product Create(Product product)
        {
            product.Id = ++lastId;
            products.Add(product);
            return product;
        }
    }
}
