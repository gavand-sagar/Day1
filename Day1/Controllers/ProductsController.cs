using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Day1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        [HttpGet]
        public List<Product> Get([FromServices] IProductService productService)
        {
            Console.WriteLine("Inside ProductsController");
            return productService.Getall();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get([FromRoute] int id, [FromServices] IProductService productService)
        {
            return productService.GetOne(id);
        }

        [HttpDelete("{id}")]
        public string Delete([FromRoute] int id, [FromServices] IProductService productService)
        {
            productService.DeleteOne(id);
            return "Product Deleted.";
        }

        [HttpPost()]
        public string Post([FromBody] Product product, [FromServices] IProductService productService)
        {
            productService.Create(product);
            return "Product Added Successfully.";
        }



    }
}
