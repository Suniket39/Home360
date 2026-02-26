using Home360.Application.Interfaces.Repositories;
using Home360.Domain.Entities;
using Home360.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;

namespace Home360.Infrastructure.Repositories
{
    public class UserManagerRepository : IUserManagerRepository
    {
        private readonly IHomeContextFactory _homeContextFactory;

        public UserManagerRepository(IHomeContextFactory homeContextFactory)
        {
            _homeContextFactory = homeContextFactory;
        }

        public async Task<bool> RegisterUserAsync(User user)
        {
            try
            {
                using HomeDbContext context = _homeContextFactory.CreateDbContext();
                user.PasswordHash = BC.HashPassword(user.PasswordHash);
                user.IsActive = true;
                context.UserManager.Add(user);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            using HomeDbContext context = _homeContextFactory.CreateDbContext();
            return await context.UserManager.ToListAsync();
        }

        public async Task<bool> UserNameExistsAsync(string userName)
        {
            try
            {
                using HomeDbContext context = _homeContextFactory.CreateDbContext();
                return await context.UserManager.AnyAsync(x => x.Username == userName);
            }
            catch (Exception ex)
            {
                return false;
            }
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
