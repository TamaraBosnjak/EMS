using EmployeeManagementSystem.ViewModels;

namespace EmployeeManagementSystem.Models
{
    public interface IJobRoleRepository
    {
        JobRole GetJobRoleById(int? id);
        JobRole GetJobRoleByName(string name);
        List<JobRole> GetJobRoles();
        void CreateJobRole(JobRole jobRole);
        void UpdateJobRole(int? id);
        void DeleteJobRole(int id);
    }
}
