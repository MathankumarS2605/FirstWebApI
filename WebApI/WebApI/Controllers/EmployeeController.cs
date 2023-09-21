using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApI.Models;

namespace WebApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public ILogger<EmployeeController> logger1;

      
        public EmployeeController(ILogger<EmployeeController> logger)
        {
            logger1 = logger;
        }

        [HttpGet]
        public List<Employee> employees()
        {
            RepositoryEmployee repositoryEmployee = new RepositoryEmployee();
            logger1.LogInformation("THESE " );
            return repositoryEmployee.Employees1();
        }
    }
}
