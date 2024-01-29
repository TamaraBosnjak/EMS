namespace EmployeeManagementSystem.Models
{
    public interface IJobRoleRepository
    {
        JobRole GetJobRoleById(int id);
        List<JobRole> GetJobRoles();
    }
}
