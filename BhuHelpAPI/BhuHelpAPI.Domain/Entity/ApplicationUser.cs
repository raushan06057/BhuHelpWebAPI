namespace BhuHelpAPI.Domain.Entity;

public class ApplicationUser:IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public string? Pwd { get; set; }
    public string? Role { get; set; }
}
