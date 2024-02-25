using EmployeeManagementSystem.DAL;
using EmployeeManagementSystem.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Models
{
    public class JobRoleRepository : IJobRoleRepository
    {
        private AppDBContext _appDBContext;

        public JobRoleRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public JobRole GetJobRoleById(int? id) 
        {
            return _appDBContext.JobRoles.Include(d => d.Department).FirstOrDefault(jr => jr.JobRoleId == id)!;
        }

        public JobRole GetJobRoleByName(string name)
        {
            return _appDBContext.JobRoles.FirstOrDefault(d => d.Title == name)!;
        }

        public List<JobRole> GetJobRoles()
        {
            return _appDBContext.JobRoles.Include(d => d.Department).ToList();
        }

        public void CreateJobRole(JobRole jobRole)
        {
            _appDBContext.Add(jobRole);
            _appDBContext.SaveChanges();
        }

        public void UpdateJobRole(int? id)
        {
            var updJR = _appDBContext.JobRoles.FirstOrDefault(d => d.JobRoleId == id);
            _appDBContext.Update(updJR);
            _appDBContext.SaveChanges();
        }

        public void DeleteJobRole(int id)
        {
            var delJR = _appDBContext.JobRoles.FirstOrDefault(d => d.JobRoleId == id);
            _appDBContext.Remove(delJR);
            _appDBContext.SaveChanges();
        }
    }
}
