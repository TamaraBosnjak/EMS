using EmployeeManagementSystem.DAL;
using EmployeeManagementSystem.Helpers;
using EmployeeManagementSystem.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _appDBContext;

        public UserRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public void CreateUser(User user, int id)
        {
            user.Password = EncryptionHelper.Encrypt(user.Password);
            user.EmployeeId = id;

            _appDBContext.Users.Add(user);
            _appDBContext.SaveChanges();
        }

        public User GetUserByEmail(string email)
        {
            return _appDBContext.Users.Include(u => u.Employee).FirstOrDefault(u => u.Email == email)!;
        }

    }
}
