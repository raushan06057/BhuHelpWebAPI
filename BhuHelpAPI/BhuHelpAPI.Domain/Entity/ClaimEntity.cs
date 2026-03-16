namespace BhuHelpAPI.Domain.Entity;
[Table(CommonFields.Claims)]
public class ClaimEntity : BaseEntity
{
    public string? ClaimType { get; set; }
    public string? ClaimValue { get; set; }
}