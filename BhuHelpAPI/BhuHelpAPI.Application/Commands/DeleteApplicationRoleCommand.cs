namespace BhuHelpAPI.Application.Commands;

public class DeleteApplicationRoleCommand : IRequest<ResponseModel>
{
    public string? Id { get; set; }
    public string? Name { get; set; }
}
