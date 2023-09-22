using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebApI.Models;

namespace WebApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
            public static List<Employee> employeeList = new List<Employee>();
            public static RepositoryEmployee repositoryEmployee;

        public EmployeeController(RepositoryEmployee _repositoryEmployee)
        {
            repositoryEmployee = _repositoryEmployee;
        }


        [HttpGet("GetEmployee")]
        public IEnumerable<EmpViewModel> GetEmployee()
        {

            // StringBuilder sb = new StringBuilder();
            List<Employee> employee = repositoryEmployee.Employees1();
            var emplist = (from emp in employee
                           select new EmpViewModel()
                           {
                               EmpId = emp.EmployeeId,
                               FirstName = emp.FirstName,
                               LastName = emp.LastName,
                               BirthDate = (DateTime)emp.BirthDate,
                               HireDate = (DateTime)emp.HireDate,
                               Title = emp.Title,
                               City = emp.City,
                               ReportTo = emp.ReportsTo
                           }).ToList();
            return emplist;
        }

        [HttpGet("FindEmployee")]

        public Employee FindEmployee(int id)
        {
            Employee employee=repositoryEmployee.GetEmployee(id);
            return employee;
        }
        [HttpDelete("DeleteEmployee")]
        public int Delete(int id)
        {
            Employee employee;
            if (id > 0)
            {
                employee = repositoryEmployee.GetEmployee(id);
                return repositoryEmployee.DeleteId(employee); ;
            }
            return 0;
           
        }

        [HttpPost("ModifyEmployee")]

        public int ModifyEmployee(EmpViewModel emp)
        {

            Employee employee = new Employee();
            employee.FirstName = emp.FirstName;
            employee.LastName = emp.LastName;
            employee.BirthDate = emp.BirthDate;
            employee.HireDate = emp.HireDate;
            employee.Title= emp.Title;  
            employee.City = emp.City;
            employee.ReportsTo=emp.ReportTo > 0 ? emp.ReportTo : null;
            // employee.EmployeeId
        
            repositoryEmployee.AddEmployee(employee);   
            return 1;
        }

        [HttpPut("AddEmployee")]
        public int AddEmployee(EmpViewModel emp)
        {
            Employee employee = new Employee();
            employee.FirstName = emp.FirstName;
            employee.LastName = emp.LastName;
            employee.BirthDate = emp.BirthDate;
            employee.HireDate = emp.HireDate;
            employee.Title = emp.Title;
            employee.City = emp.City;
            employee.ReportsTo = emp.ReportTo > 0 ? emp.ReportTo : null;
            repositoryEmployee.ModifyEmployee(employee);

            return 1;

        }
    }

}
