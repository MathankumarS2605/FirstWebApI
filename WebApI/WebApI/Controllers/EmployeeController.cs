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
            List<Employee> employee = repositoryEmployee.EmployeesList();
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

        public EmpViewModel FindEmployee(int id)
        {
            EmpViewModel employeeView = new EmpViewModel(); 
            Employee emp=repositoryEmployee.FindEmployee(id);
            employeeView.FirstName = emp.FirstName;
            employeeView.LastName = emp.LastName;
            employeeView.BirthDate = emp.BirthDate;
            employeeView.HireDate = emp.HireDate;
            employeeView.Title = emp.Title;
            employeeView.City = emp.City;
            employeeView.ReportTo = emp.ReportsTo;
            return employeeView;
        }
        [HttpDelete("DeleteEmployee")]
        public int Delete(int id)
        {
            Employee employee;
            if (id > 0)
            {
                employee = repositoryEmployee.FindEmployee(id);
                return repositoryEmployee.DeleteId(employee); ;
            }
            return 0;
           
        }

        [HttpPost("ModifyEmployee")]


        public int ModifyEmployee(int id ,EmpViewModel emp)
        {

            Employee employee = new Employee();
            employee.FirstName = emp.FirstName;
            employee.LastName = emp.LastName;
            employee.BirthDate = emp.BirthDate;
            employee.HireDate = emp.HireDate;
            employee.Title = emp.Title;
            employee.City = emp.City;
            employee.ReportsTo = emp.ReportTo > 0 ? emp.ReportTo : null;
            // employee.EmployeeId

            repositoryEmployee.AddEmployee(employee);
            return 1;
        }
        [HttpGet("GetAllEmployeeIds")]
        public List<int> GetAllEmployeeIds()
        {
            List<int> ids =repositoryEmployee.GetEmployeeIds();
            if(ids.Count <= 0)
            {
                throw new Exception("Not Avaible");
            }
            return ids; 
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
