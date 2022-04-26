using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Dedicated_REST_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class API : ControllerBase
    {
       
        private readonly ILogger<API> _logger;

        public API(ILogger<API> logger)
        {
            _logger = logger;
        }

        
        [HttpGet(Name = "GetListOfNumbers")]
        public OkObjectResult GetListOfNumbers()
        {
            var random = new Random();
            int ExitCondition = 700;
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            while (ExitCondition != 0)
            {
                int value1 = random.Next();
                int value2 = random.Next();
                int value3 = value1 * value1 + value2 * value2;
                list1.Add(value1);
                list2.Add(value3);
                list1.Add(value2);
                list1.Add(value1 * value3);
                list1 = list1.Concat(list2).ToList();
               
                ExitCondition--;
            }
            list2.Sort();
            string output = "Sorted List: ";
            for (int i = 0; i < list2.Count; i++)
            {
                output = output + list2[i] + ", ";
                
            }
            output = output + " END";
            string responseMessage = output;

            return new OkObjectResult(responseMessage);
        }
    }
}