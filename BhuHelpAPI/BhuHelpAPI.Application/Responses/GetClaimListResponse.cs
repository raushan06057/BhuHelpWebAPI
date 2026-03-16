namespace BhuHelpAPI.Application.Responses;

public class GetClaimListResponse
{
    public List<ClaimEntity> Claims { get; set; }
    public int TotalCount { get; set; }
}
