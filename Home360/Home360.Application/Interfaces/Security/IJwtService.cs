using Home360.Domain.Entities;

namespace Home360.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateAccessToken(User user);
    }
}
