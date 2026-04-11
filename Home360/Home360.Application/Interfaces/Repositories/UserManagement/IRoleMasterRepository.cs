using Home360.Domain.Entities;

namespace Home360.Application.Interfaces
{
    public interface IRoleMasterRepository
    {
        Task<bool> RegisterRoleAsync(RoleMaster user);
        Task<List<RoleMaster>> GetAllRolesAsync();
        Task<bool> RoleNameExistsAsync(string roleName);
    }
}
