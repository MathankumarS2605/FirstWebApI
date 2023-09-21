namespace WebApI.Models
{
    public class RepositoryEmployee
    {
        public NorthwindContext Context = new NorthwindContext();
       

         public RepositoryEmployee() { }
        public List<Employee> Employees1()
        {
           
            return Context.Employees.ToList();
        }
        public Employee GetEmployee(int id)
        {
            var Employee = Context.Employees.Find(id);
            return Employee;
        }
        public List<int> GetEmployeeIds()
        {
            List<int> EmployeeIds = new List<int>();    
            foreach(var id in Context.Employees)
            {
                EmployeeIds.Add(id.EmployeeId);
            }
            return EmployeeIds; 
        }
    }
}
