namespace BhuHelpAPI.Application.Commands;

public class CreateApplicationUserCommand : IRequest<ResponseModel>
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Pwd { get; set; }
    public string? Role { get; set; }
    public string? PhoneNumber { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public List<Claim> ClaimList { get; set; }
    public CreateApplicationUserCommand()
    {
        ClaimList = new();
    }
}