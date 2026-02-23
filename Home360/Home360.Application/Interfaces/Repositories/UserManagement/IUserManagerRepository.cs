namespace Home360.Application.Interfaces.Repositories
{
    public interface IUserManagerRepository
    {
        Task<bool> UserExistsAsync(string userName, string mobileNo, string email);
    }
}
