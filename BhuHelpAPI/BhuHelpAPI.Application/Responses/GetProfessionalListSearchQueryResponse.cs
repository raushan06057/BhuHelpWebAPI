namespace BhuHelpAPI.Application.Responses;

public class GetProfessionalListSearchQueryResponse
{
    public List<ProfessionalEntity> Professionals { get; set; }
    public int TotalCount { get; set; }
}
