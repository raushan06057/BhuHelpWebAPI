namespace BhuHelpAPI.Application.Responses;

public class GetBhuInfoListResponse
{
    public List<BhuInfoEntity> BhuInfos { get; set; }
    public int TotalCount { get; set; }
}
