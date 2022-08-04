using Interview.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Linq;

namespace Interview 
{ 
    [Route("correlation")]
    public class CorrelationController : Controller
    { 
        private readonly IValetService service;
        private readonly ICorrelationCalculator calculator;

        public CorrelationController(IValetService service, ICorrelationCalculator calculator)
        {
            this.service = service;
            this.calculator = calculator;
        }

        [HttpGet]
        [Route("date")]
        public async Task<ActionResult<CalcResult>> Get([FromQuery]string startDate, [FromQuery]string endDate)
        { 
            try
            {
                if (!DateTime.TryParseExact(startDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _) ||
                    !DateTime.TryParseExact(startDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                {
                    return BadRequest("Date format is invalid");
                }
                var response = await service.GetObervationsByDate(startDate, endDate);
                return calculator.GetCalcResult(response);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }
    } 
}
