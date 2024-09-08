using EmployeeManagementSystem.DAL;
using EmployeeManagementSystem.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private AppDBContext _appDBContext;

        public EmployeeRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public Employee GetEmployeeById(int id)
        {
            return _appDBContext.Employees.Include(e => e.Department).FirstOrDefault(e => e.EmployeeId == id)!;
        }

        public Employee GetEmployeeByEmail(string email) 
        {
            return _appDBContext.Employees.FirstOrDefault(e => e.Email == email)!;
        }

        [TypeFilter(typeof(CustomExceptionFilter))]
        public List<Employee> ListOfAllEmployees()
        {
             return _appDBContext.Employees.Include(e => e.JobRole).ThenInclude(jr => jr.Department).ToList();
        }

        public void CreateEmp(Employee employee)
        {
            _appDBContext.Add(employee);
            _appDBContext.SaveChanges();
        }

        public void UpdateEmp(int id) 
        {
            var updEmp = _appDBContext.Employees.FirstOrDefault(u => u.EmployeeId == id);
            _appDBContext.Update(updEmp);
            _appDBContext.SaveChanges();
        }

        public void DeleteEmp(int id) 
        {
            var delEmp = _appDBContext.Employees.FirstOrDefault(d => d.EmployeeId == id);
            _appDBContext.Remove(delEmp);
            _appDBContext.SaveChanges();
        }
    }
}
