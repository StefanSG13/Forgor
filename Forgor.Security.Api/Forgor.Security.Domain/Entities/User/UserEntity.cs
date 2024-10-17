namespace Forgor.Security.Domain.Entities.User;
public sealed class UserEntity
{
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime CreatedDatetime { get; set; }
    public UserSecurityEntity UserSecurity { get; set; }
}
