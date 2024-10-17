namespace Forgor.Security.Domain.Entities.User;

public sealed class UserSecurityEntity
{
    public int UserId { get; set; }
    public string Password { get; set; }
    public string PasswordHash { get; set; }
    public int RetryCount { get; set; }
    public int UseTwoFactor { get; set; }
    public int UserStatusId { get; set; }
    public DateTime CreatedDatetime { get; set; }
}
