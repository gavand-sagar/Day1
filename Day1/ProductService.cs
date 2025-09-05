using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Day1
{
    public class ProductService : IProductService
    {
        int lastId = 0;
        List<Product> products = new List<Product>();
        IRepository<Product> repository;
        public ProductService(IRepository<Product> repository)
        {
            this.repository = repository;
        }

        public List<Product> Getall()
        {
            return repository.GetAll().ToList();
        }

        public Product GetOne(int id)
        {
            return products.Find(x => x.Id == id);
        }

        public bool DeleteOne(int id)
        {
            products = products.Where(x => x.Id != id).ToList();
            return true;
        }

        public Product Create(Product product)
        {
            product.Id = ++lastId;
            repository.Insert(product);
            return product;
        }
    }
}
