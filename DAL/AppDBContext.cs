using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.DAL
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : 
            base(options)
        {
        }
        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobRole> JobRoles { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
