using EmployeeManagementSystem.ViewModels;

namespace EmployeeManagementSystem.Models
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        User GetUserByEmail(string username);
    }
}
