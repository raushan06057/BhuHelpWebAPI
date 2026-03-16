namespace BhuHelpAPI.Application.Queries;

public class GetPostOfficeListByDistrictIdQuery:IRequest<ResponseModel>
{
    public long DistrictId {  get; set; }
    public GetPostOfficeListByDistrictIdQuery(long districtId)
    {
        DistrictId = districtId;
    }
}
