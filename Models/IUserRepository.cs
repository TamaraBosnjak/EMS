using EmployeeManagementSystem.ViewModels;

namespace EmployeeManagementSystem.Models
{
    public interface IUserRepository
    {
        void CreateUser(User user, int id);
        User GetUserByEmail(string username);
    }
}
