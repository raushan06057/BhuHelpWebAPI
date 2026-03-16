namespace BhuHelpAPI.Application.Queries;

public class GetDistrictListByStateIdQuery:IRequest<ResponseModel>
{
    public long StateId { get; set; }
    public GetDistrictListByStateIdQuery(long stateId)
    {
        StateId= stateId;
    }
}
