using Forgor.Security.DataAccess.SqlClients;
using Forgor.Security.Domain.Entities.User;
using Forgor.Security.Repositories.Interfaces;

namespace Forgor.Security.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresSqlClient _sqlClient;

    public UserRepository(IPostgresSqlClient sqlClient)
    {
        _sqlClient = sqlClient;
    }

    public async Task<int> AddUserAsync(UserEntity user)
    {
        var sql = @"
            INSERT INTO security.user (first_name, last_name, email) 
            VALUES (@FirstName, @LastName, @Email)";

        var id = await _sqlClient.InsertReturningIdAsync(sql, "user_id", user);

        return id;
    }

    public async Task AddUserSecurityAsync(UserSecurityEntity userSecurity)
    {
        var sql = @"
            INSERT INTO security.user_security (user_id, password_hash, password_salt, retry_count, use_two_factor, user_status_id) 
            VALUES (@UserId, @PasswordHash, @PasswordSalt, @RetryCount, @UseTwoFactor, @UserStatusId)";

        await _sqlClient.InsertAsync(sql, userSecurity);
    }

    public async Task<UserSecurityEntity?> GetUserSecurityByEmailAsync(string email)
    {
        var sql = @"
            SELECT US.user_id AS UserId, 
                   US.password_hash AS PasswordHash, 
                   US.password_salt AS PasswordSalt, 
                   US.retry_count AS RetryCount, 
                   US.use_two_factor AS UseTwoFactor, 
                   US.user_status_id AS UserStatusId 
            FROM security.user_security US
            JOIN security.user U 
                ON US.user_id = U.user_id
            WHERE U.email = @Email";

        return await _sqlClient.GetAsync<UserSecurityEntity?>(sql, new { Email = email });
    }
}
