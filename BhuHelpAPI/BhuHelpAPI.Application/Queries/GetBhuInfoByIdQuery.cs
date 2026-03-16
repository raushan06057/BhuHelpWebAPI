namespace BhuHelpAPI.Application.Queries;

public class GetBhuInfoByIdQuery : IRequest<ResponseModel>
{
    public long id { get; set; }
    public GetBhuInfoByIdQuery(long id)
    {
        this.id = id;
    }
}