using Home360.Domain.Entities;

namespace Home360.Application.Interfaces.Repositories
{
    public interface IRoleAccessManagerRepository
    {
        Task<bool> RegisterRoleAccessManagerAsync(RoleAccessManager screen);
        Task<List<RoleAccessManager>> GetAllRoleAccessAsync();
        //Task<bool> ScreenCodeExistsAsync(string screenCode);
    }
}
