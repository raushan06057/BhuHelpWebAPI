namespace BhuHelpAPI.Application.Queries;

public class GetUserDetailsByIdQuery : IRequest<ResponseModel>
{
    public string? id { get; set; }
    public GetUserDetailsByIdQuery(string id)
    {
        this.id = id;
    }
}