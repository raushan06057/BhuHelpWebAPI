namespace BhuHelpAPI.Application.Commands;

public class UpdateApplicationRoleCommand : IRequest<ResponseModel>
{
    public string? Id { get; set; }
    public string? Name { get; set; }
}
