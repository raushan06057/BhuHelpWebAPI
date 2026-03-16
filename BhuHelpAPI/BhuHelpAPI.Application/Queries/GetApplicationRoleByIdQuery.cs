namespace BhuHelpAPI.Application.Queries;

public class GetApplicationRoleByIdQuery : IRequest<ResponseModel>
{
    public GetApplicationRoleByIdQuery(string id)
    {
        Id = id;
    }
    public string Id { get; set; }
}
