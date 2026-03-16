namespace BhuHelpAPI.Application.Responses;

public class GetGotraListSearchQueryResponse
{
    public List<GotraEntity> Gotras { get; set; }
    public int TotalCount { get; set; }
}
