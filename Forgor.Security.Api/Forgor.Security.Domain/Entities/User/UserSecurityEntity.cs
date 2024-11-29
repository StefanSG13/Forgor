using Forgor.Security.Domain.Enums;

namespace Forgor.Security.Domain.Entities.User;

public sealed class UserSecurityEntity
{
    public int UserId { get; set; }
    public string PasswordSalt { get; set; }
    public string PasswordHash { get; set; }
    public int RetryCount { get; set; }
    public bool UseTwoFactor { get; set; }
    public UserStatus UserStatusId { get; set; }
    public DateTime CreatedDatetime { get; set; }
}
