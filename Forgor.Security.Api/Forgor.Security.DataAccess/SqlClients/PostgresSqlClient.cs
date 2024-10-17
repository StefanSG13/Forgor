using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Forgor.Security.DataAccess.SqlClients;

internal class PostgresSqlClient : IPostgresSqlClient
{
    private readonly string _connectionString;

    public PostgresSqlClient(IConfiguration configuration)
    {
        _connectionString = @$"Host={configuration["POSTGRES_HOST"]};
                               Port={configuration["POSTGRES_PORT"]};
                               Database={configuration["POSTGRES_DATABASE"]};
                               User Id={configuration["POSTGRES_USERNAME"]};
                               Password={configuration["POSTGRES_PASSWORD"]};";
    }

    public Task DeleteAsync(string sql, object parameters = default!)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetAllAsync<T>(string sql, object parameters = default!)
    {
        throw new NotImplementedException();
    }

    public Task<T> GetAsync<T>(string sql, object parameters = default!)
    {
        throw new NotImplementedException();
    }

    public async Task InsertAsync(string sql, object parameters = default!)
    {
        using var con = CreateConnection();
        await con.OpenAsync();

        await con.ExecuteAsync(sql);
        
        await con.CloseAsync();
    }

    public async Task<int> InsertReturningIdAsync(string sql, string idColumnName, object parameters = default!)
    {
        sql += $@"
            RETURNING {idColumnName};";

        using var con = CreateConnection();
        await con.OpenAsync();

        var id = await con.QuerySingleAsync<int>(sql, parameters);

        await con.CloseAsync();

        return id;
    }

    public Task<int> UpdateAsync(string sql, object parameters = default!)
    {
        throw new NotImplementedException();
    }

    private NpgsqlConnection CreateConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}
