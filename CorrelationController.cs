using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Interview 
{ 
    [Route("correlation")]
    public class CorrelationController : Controller
    { 
        private readonly IValetService service;

        public CorrelationController(IValetService service)
        {
            this.service = service;
        }

        // GET api/values 
        public IEnumerable<string> Get([FromQuery]string startDate, [FromQuery]string endDate)
        { 
            return new string[] { "value1", "value2" }; 
        } 

        [HttpGet]
        [Route("ping")]
        public async Task<double> Ping() 
        { 
            var response = await service.GetObervationsByDate("2022-06-21", "2022-06-22");
            return response.Observations.First().CorraRate.Value;
        }
    } 
}
