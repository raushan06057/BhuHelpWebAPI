namespace BhuHelpAPI.Application.Queries;

public class GetStateListByCountryIdQuery:IRequest<ResponseModel>
{
    public long CountryId { get; set; }
    public GetStateListByCountryIdQuery(long CountryId)
    {
        this.CountryId = CountryId;
    }
}
