using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;

namespace WebApI.Models
{
    public class RepositoryEmployee
    {
        private NorthwindContext Context;


        public RepositoryEmployee(NorthwindContext context)
        {
            Context = context;
        }
       


        public int DeleteId(Employee emp)
        {

            EntityState es = Context.Entry(emp).State;
            Console.WriteLine($"EntityState B4 Delete:{es.GetDisplayName()}");
            Context.Employees.Update(emp);
            es = Context.Entry(emp).State;
            Console.WriteLine($"EntityState B4 Delete:{es.GetDisplayName()}");
            int result = Context.SaveChanges();
            es = Context.Entry(emp).State;
            Console.WriteLine($"EntityState B4 SaveChanges:{es.GetDisplayName()}");
            Context.Employees.Remove(emp);
            Context.SaveChanges();

            return 1;
        }

        public void AddEmployee(Employee emp)
        {
            Employee? foundEmp=Context.Employees.Find(emp.EmployeeId);
            if (foundEmp != null)
            {
                throw new Exception("failed to add");
            }
            EntityState es = Context.Entry(emp).State;
            Console.WriteLine($"EntityState B4 Add:{es.GetDisplayName()}");
            Context.Employees.Add(emp);
            es=Context.Entry(emp).State;
            Console.WriteLine($"EntityState B4 Add:{es.GetDisplayName()}");
            int result = Context.SaveChanges();
            es = Context.Entry(emp).State;
            Console.WriteLine($"EntityState B4 SaveChanges:{es.GetDisplayName()}");
            //ctx.Entry(patient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
           
         
        }
         
        public List<Employee> Employees1()
        {
           
            return Context.Employees.ToList();
        }
        public Employee GetEmployee(int id)
        {
            Employee employee = Context.Employees.Find(id);
            return employee;
        }
        public List<int> GetEmployeeIds()
        {
            List<int> EmployeeIds = new List<int>();
            foreach (var id in Context.Employees)
            {
                EmployeeIds.Add(id.EmployeeId);
            }
            return EmployeeIds;
        }

        public  void ModifyEmployee(Employee emp)
        {

            if (emp != null)
            {
                EntityState es = Context.Entry(emp).State;
                Console.WriteLine($"EntityState B4 Modified:{es.GetDisplayName()}");
                Context.Employees.Update(emp);
                es = Context.Entry(emp).State;
                Console.WriteLine($"EntityState B4 Modified:{es.GetDisplayName()}");
                int result = Context.SaveChanges();
                es = Context.Entry(emp).State;
                Console.WriteLine($"EntityState B4 SaveChanges:{es.GetDisplayName()}");
            }
        }
    }
}
