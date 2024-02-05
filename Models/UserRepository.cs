using EmployeeManagementSystem.DAL;
using EmployeeManagementSystem.Helpers;
using EmployeeManagementSystem.ViewModels;

namespace EmployeeManagementSystem.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _appDBContext;

        public UserRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public void CreateUser(User user)
        {
            user.Password = EncryptionHelper.Encrypt(user.Password);

            _appDBContext.Users.Add(user);
            _appDBContext.SaveChanges();
        }

        public User GetUserByEmail(string email)
        {
            return _appDBContext.Users.FirstOrDefault(u => u.Email == email)!;
        }
    }
}
