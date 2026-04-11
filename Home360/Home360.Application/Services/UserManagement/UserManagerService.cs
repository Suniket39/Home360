using AutoMapper;
using Home360.Application.DTOs;
using Home360.Application.Interfaces.Repositories;
using Home360.Application.Interfaces.Services;
using Home360.Domain.Common;
using Home360.Domain.Entities;
using BC = BCrypt.Net.BCrypt;

namespace Home360.Application.Services
{
    public class UserManagerService : IUserManagerService
    {
        private readonly IUserManagerRepository _userManagerRepository;
        private readonly IMapper _mapper;
        public UserManagerService(IUserManagerRepository userManagerRepository,
            IMapper mapper)
        {
            _userManagerRepository = userManagerRepository;
            _mapper = mapper;
        }

        public async Task<string> RegisterUserAsync(UserRquest userRequest)
        {
            bool userExists = await _userManagerRepository.UserNameExistsAsync(userRequest.Username);
            if(userExists) return "User Name already exists";

            // ToDo -  Write Same for MobileNo and Email

            var user = _mapper.Map<User>(userRequest);
            user.PasswordHash = BC.HashPassword(user.PasswordHash);
            user.IsActive = true;
            user.CreatedDate = DateTimeFormatter.GetISTTime(DateTime.Now);

            bool userAdded = await _userManagerRepository.RegisterUserAsync(user);
            return userAdded ? "User Registered Successfully" : "User Registration Failed";
        }

        public async Task<UserResponse> ValidateCredentialsAsync(LoginRequest loginRequest)
        {
            var userAccount = await _userManagerRepository.ActiveUserExistsAsync(loginRequest.Username);

            if (userAccount == null || BC.Verify(loginRequest.Username, userAccount.PasswordHash))
                throw new UnauthorizedAccessException("Invalid username or password.");

            return _mapper.Map<UserResponse>(userAccount);
        }

        public async Task<List<UserResponse>> GetAllUsersAsync()
        {
            return _mapper.Map<List<UserResponse>>(await _userManagerRepository.GetAllUsersAsync());
        }
    }
}
