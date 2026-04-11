using Home360.Application.DTOs;

namespace Home360.Application.Interfaces.Services
{
    public interface IRoleMasterService
    {
        Task<string> RegisterRoleAsync(RoleMasterRequest role);
        Task<List<RoleMasterResponse>> GetAllRolesAsync();
    }
}
