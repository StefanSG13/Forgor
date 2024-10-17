using Forgor.Security.DataAccess.SqlClients;
using Forgor.Security.Domain.Entities.User;
using Forgor.Security.Repositories.Interfaces;

namespace Forgor.Security.DataAccess.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly IPostgresSqlClient _sqlClient;

    public UserRepository(IPostgresSqlClient sqlClient)
    {
        _sqlClient = sqlClient;
    }

    public async Task<int> AddUserAsync(UserEntity user)
    {
        var sql = "";

        var id = await _sqlClient.InsertReturningIdAsync(sql, nameof(user.UserId), user);
    
        return id;
    }

    public async Task AddUserSecurityAsync(UserSecurityEntity userSecurity)
    {
        var sql = "";

        await _sqlClient.InsertAsync(sql, userSecurity);
    }
}
