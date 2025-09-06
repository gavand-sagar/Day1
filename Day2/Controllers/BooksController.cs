using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Day2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class BooksController : ControllerBase
    {
        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Task.Delay(1000).Wait();
            return new string[] { "value1", "value2" };
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BooksController>
        [HttpPost]
        public ActionResult<BookEntity> Post(
            [FromBody] BookDTO value,
            [FromServices] IValidator<BookDTO> validator,
            [FromServices] IMapper mapper)
        {
            var result = validator.Validate(value, options =>
            {
                options.IncludeProperties(x => x.Title);
            });
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            // Save to database;
            BookEntity entity = mapper.Map<BookEntity>(value);

            //BookDTO dto = mapper.Map<BookDTO>(entity);
            return entity;
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
