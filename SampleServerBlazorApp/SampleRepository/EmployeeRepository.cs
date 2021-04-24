using SampleData;
using SampleModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SampleDbContext _appDbContext;

        public EmployeeRepository(SampleDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _appDbContext.Employee;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return _appDbContext.Employee.FirstOrDefault(c => c.EmployeeId == employeeId);
        }

        public Employee AddEmployee(Employee employee)
        {
            var addedEntity = _appDbContext.Employee.Add(employee);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var foundEmployee = _appDbContext.Employee.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);

            if (foundEmployee != null)
            {
                foundEmployee.Name = employee.Name;
                foundEmployee.Gender = employee.Gender;
                foundEmployee.Department = employee.Department;
                foundEmployee.City = employee.City;

                _appDbContext.SaveChanges();

                return foundEmployee;
            }

            return null;
        }

        public void DeleteEmployee(int employeeId)
        {
            var foundEmployee = _appDbContext.Employee.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (foundEmployee == null) return;

            _appDbContext.Employee.Remove(foundEmployee);
            _appDbContext.SaveChanges();
        }
    }
}
