using Home360.Application.DTOs;

namespace Home360.Application.Interfaces.Services
{
    public interface IRoleAccessManagerService
    {
        Task<string> RegisterRoleAccessAsync(RoleAccessManagerRequest role);
        Task<List<RoleAccessManagerResponse>> GetAllRoleAccessAsync();
        Task<List<RoleAccessManagerResponse>> GetRoleAccessOnRoleIdAsync(int roleId);
    }
}
