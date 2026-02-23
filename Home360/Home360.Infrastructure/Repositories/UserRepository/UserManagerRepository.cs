using Home360.Application.Interfaces.Repositories;

namespace Home360.Infrastructure.Repositories
{
    public class UserManagerRepository : IUserManagerRepository
    {
        public UserManagerRepository()
        {
            
        }

        public Task<bool> UserExistsAsync(string userName, string mobileNo, string email)
        {
            throw new NotImplementedException();
        }   
    }
}
