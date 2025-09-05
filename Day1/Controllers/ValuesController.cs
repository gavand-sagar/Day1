using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private List<int> _values;
        private List<string> _valuesNames;
        public ValuesController()
        {
            _values = new List<int>() { 3, 4, 5, 7, 8, 3, 5, 8 };
            _valuesNames = new List<string>() { "Amit", "Sagar", "Rahul", "Raj", "Rohan", "Shreyas" };

        }


        [HttpGet("Names")]
        public List<string> GetNamesStartWithS([FromHeader] string? startValue, [FromHeader] string? endValue)
        {
            return _valuesNames
                .Where(x =>
                            (startValue == null || x.StartsWith(startValue)) &&
                            (endValue == null || x.EndsWith(endValue))
                ).ToList();
        }

        // api/values/all
        [HttpGet("all/{age}")]
        public List<int> Get([FromRoute]int age)
        {
            int result = 34 / age;
            return _values;
        }

        // api/values/even
        [HttpGet("even")]
        public List<int> GetEvenNumbers()
        {
            return _values.Where(x => x % 2 == 0).ToList();
        }


        // api/values/odd
        [HttpGet("odd")]
        public List<int> GetOddNumbers()
        {
            return _values.Where(x => x % 2 != 0).ToList();
        }


    }
}
