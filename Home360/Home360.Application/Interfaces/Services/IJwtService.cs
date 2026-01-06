using Home360.Domain.Entities;
using Home360.Domain.Entities.UserManagement;

namespace Home360.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateAccessToken(User user);
    }
}
