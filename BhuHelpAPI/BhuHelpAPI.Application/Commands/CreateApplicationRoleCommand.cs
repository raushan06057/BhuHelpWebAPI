namespace BhuHelpAPI.Application.Commands;

public class CreateApplicationRoleCommand:IRequest<ResponseModel>
{
    public string Name { get; set; } = string.Empty;
}