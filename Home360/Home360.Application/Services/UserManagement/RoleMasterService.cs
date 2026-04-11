using AutoMapper;
using Home360.Application.DTOs;
using Home360.Application.Interfaces;
using Home360.Application.Interfaces.Services;
using Home360.Domain.Entities;

namespace Home360.Application.Services
{
    public class RoleMasterService : IRoleMasterService
    {
        private readonly IRoleMasterRepository _roleMasterRepository;
        private readonly IMapper _mapper;

        public RoleMasterService(IRoleMasterRepository roleMasterRepository, IMapper mapper)
        {
            _roleMasterRepository = roleMasterRepository;
            _mapper = mapper;
        }

        public async Task<string> RegisterRoleAsync(RoleMasterRequest roleRequest)
        {
            var nameExists = await _roleMasterRepository.RoleNameExistsAsync(roleRequest.RoleName);
            if (nameExists) return "Role Name already exists!";

            var role = _mapper.Map<RoleMaster>(roleRequest);

            bool roleAdded = await _roleMasterRepository.RegisterRoleAsync(role);
            return roleAdded ? "Role Added Successfully" : "Role failed to add!";
        }

        public async Task<List<RoleMasterResponse>> GetAllRolesAsync()
        {
            // Add Cache as Data will not change Frequently
            var roles = _mapper.Map<List<RoleMasterResponse>>(await _roleMasterRepository.GetAllRolesAsync());
            return roles;
        }
    }
}
