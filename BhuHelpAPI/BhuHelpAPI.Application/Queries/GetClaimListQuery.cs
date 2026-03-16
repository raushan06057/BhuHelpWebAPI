namespace BhuHelpAPI.Application.Queries;

public class GetClaimListQuery : IRequest<ResponseModel>
{
    public string? Search { get; set; }
    public int PageSize { get; set; }
    public int Page { get; set; }
    public GetClaimListQuery(string Search, int PageSize, int Page)
    {
        this.Search = Search;
        this.PageSize = PageSize;
        this.Page = Page;
    }
}