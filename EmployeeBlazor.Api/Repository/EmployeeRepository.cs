using EmployeeBlazor.Entity;

namespace EmployeeBlazor.Api2.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Employee AddEmployee(Employee employee)
        {
            _appDbContext.Employees.Add(employee);
            _appDbContext.SaveChanges();
            return employee;
        }

        public void DeleteEmployee(int employeeId)
        {
            var foundEmployee = _appDbContext.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (foundEmployee == null) return;

            _appDbContext.Employees.Remove(foundEmployee);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _appDbContext.Employees;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return _appDbContext.Employees.Find(employeeId);
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var updateEmployee = _appDbContext.Employees.Find(employee.EmployeeId);
            if (updateEmployee != null)
            {
                updateEmployee.FirstName = employee.FirstName;
                updateEmployee.LastName = employee.LastName;
                updateEmployee.JobName = employee.JobName;
                updateEmployee.IsSelected = employee.IsSelected;
                _appDbContext.SaveChanges();
                return updateEmployee;
            }
            return null;
        }
    }
}
