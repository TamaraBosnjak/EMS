using EmployeeManagementSystem.DAL;

namespace EmployeeManagementSystem.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _appDBContext;

        public UserRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
    }
}
