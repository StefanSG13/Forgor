using Forgor.Security.Domain.Entities.User;

namespace Forgor.Security.Repositories.Interfaces;
public interface IUserRepository
{
    Task<int> AddUserAsync(UserEntity user);
    Task AddUserSecurityAsync(UserSecurityEntity userSecurity);
    Task<UserSecurityEntity?> GetUserSecurityByEmailAsync(string email);
}
