using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        // api/Calculator/Add?x=9&y=15
        [HttpGet("Add")]
        public int Add(int x,int y)
        {
            return x + y ;
        }

        //api/Calculator/subtract? x = 100 & y = 15
        [HttpGet("Sub")]
        public int Sum(int x, int y)
        {
            return x + y ;
        }
        // api/Calculator/Multiply?x=100&y=15
        [HttpGet("Mul")]
        public int Multiply(int x, int y)
        {
            return x * y;
        }
        // api/Calculator/Division?x=100&y=15
        [HttpGet("Division")]
        public int Division(int x, int y)
        {
            return x / y;
        }

    }
}
