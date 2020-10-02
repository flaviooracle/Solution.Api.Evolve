using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Solution.Api.Evolve.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string start()
        {
            return "Digite dois valores separados pela barra";
        }

        [HttpGet("{first}/{second}")]
        public IActionResult Sum(string first, string second)
        {
            if (IsNumeric(first) && IsNumeric(second)) {
                var sum = ConvertToDecimal(first) + ConvertToDecimal(second);
                return Ok(sum);
            }

            return BadRequest("invalid input of values");
        }


        private Boolean IsNumeric(string num)
        {
            double value;
            bool isNumeric = double.TryParse(num, System.Globalization.NumberStyles.Any,
                                                   System.Globalization.NumberFormatInfo.InvariantInfo,
                                                   out value);
            return isNumeric;
        }

        private Decimal ConvertToDecimal(string num)
        {
            decimal value;
            if (decimal.TryParse(num,out value))
            {
                return value;
            }
            return 0;
        }
    }
}
