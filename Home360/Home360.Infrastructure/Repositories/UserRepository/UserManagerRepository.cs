using Home360.Application.Interfaces.Repositories;
using Home360.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Home360.Infrastructure.Repositories
{
    public class UserManagerRepository : IUserManagerRepository
    {
        private readonly IHomeContextFactory _homeContextFactory;

        public UserManagerRepository(IHomeContextFactory homeContextFactory)
        {
            _homeContextFactory = homeContextFactory;
        }

        public async Task<bool> UserExistsAsync(string userName, string mobileNo, string email)
        {
            try
            {
                using HomeDbContext context = _homeContextFactory.CreateDbContext();

                if(await context.UserManager.AnyAsync(x => x.Username == userName ||
                                                x.Email == email))
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }   
    }
}
