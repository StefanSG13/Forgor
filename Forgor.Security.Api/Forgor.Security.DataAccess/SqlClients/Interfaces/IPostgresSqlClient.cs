namespace Forgor.Security.DataAccess.SqlClients;

internal interface IPostgresSqlClient
{
    Task<T> GetAsync<T>(string sql, object parameters = default!);
    Task<IEnumerable<T>> GetAllAsync<T>(string sql, object parameters = default!);
    Task<int> InsertReturningIdAsync(string sql, string idColumnName, object parameters = default!);
    Task InsertAsync(string sql, object parameters = default!);
    Task<int> UpdateAsync(string sql, object parameters = default!);
    Task DeleteAsync(string sql, object parameters = default!);
}
