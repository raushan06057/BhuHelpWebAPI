namespace BhuHelpAPI.Application.Queries;

public class GetProfessionalListSearchQuery:IRequest<ResponseModel>
{
    public string? Search { get; set; }
    public int PageSize { get; set; }
    public int Page { get; set; }
    public GetProfessionalListSearchQuery(string Search, int PageSize, int Page)
    {
        this.Search = Search;
        this.PageSize = PageSize;
        this.Page = Page;
    }
}
