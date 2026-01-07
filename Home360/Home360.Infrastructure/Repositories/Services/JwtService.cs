using Home360.Application.Interfaces;
using Home360.Domain.Entities;

namespace Home360.Infrastructure.Repositories
{
    public class JwtService : IJwtService
    {
        public string GenerateAccessToken(User user)
        {
            return "";
        }
    }
}
