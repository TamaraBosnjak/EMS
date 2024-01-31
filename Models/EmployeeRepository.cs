﻿using EmployeeManagementSystem.DAL;
using EmployeeManagementSystem.Models;
using System.Linq;
using System.Collections.Generic;

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
            return _appDBContext.Employees.FirstOrDefault(e => e.EmployeeId == id)!;
        }
        
        public List<Employee> GetAllEmployees { get
            {
                return _appDBContext.Employees.ToList();
            }
        }

        public void CreateEmp(Employee employee)
        {
            _appDBContext.Add(employee);
            _appDBContext.SaveChanges();
        }
    }
}
