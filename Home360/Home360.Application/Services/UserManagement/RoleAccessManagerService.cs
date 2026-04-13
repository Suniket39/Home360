using AutoMapper;
using Home360.Application.DTOs;
using Home360.Application.Interfaces.Repositories;
using Home360.Application.Interfaces.Services;
using Home360.Domain.Entities;

namespace Home360.Application.Services
{
    public class RoleAccessManagerService : IRoleAccessManagerService
    {
        private readonly IRoleAccessManagerRepository _roleAccessRepository;
        private readonly IMapper _mapper;

        public RoleAccessManagerService(IRoleAccessManagerRepository roleAccessRepository, IMapper mapper)
        {
            _roleAccessRepository = roleAccessRepository;
            _mapper = mapper;
        }

        public async Task<string> RegisterRoleAccessAsync(RoleAccessManagerRequest roleAccessRequest)
        {
            //var nameExists = await _roleAccessRepository.Ro(roleRequest.RoleName);
            //if (nameExists) return "Role Name already exists!";

            var roleAccess = _mapper.Map<RoleAccessManager>(roleAccessRequest);

            bool roleAccessAdded = await _roleAccessRepository.RegisterRoleAccessManagerAsync(roleAccess);
            return roleAccessAdded ? "Role Access Added Successfully" : "Role Access failed to add!";
        }

        public async Task<List<RoleAccessManagerResponse>> GetAllRoleAccessAsync()
        {
            // Add Cache as Data will not change Frequently
            var roles = _mapper.Map<List<RoleAccessManagerResponse>>(await _roleAccessRepository.GetAllRoleAccessAsync());
            return roles;
        }
    }
}

