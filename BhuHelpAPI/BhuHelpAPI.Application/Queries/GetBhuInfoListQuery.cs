namespace BhuHelpAPI.Application.Queries;

public class GetBhuInfoListQuery : IRequest<ResponseModel>
{
    public string? Search { get; set; }
    public int PageSize { get; set; }
    public int Page { get; set; }
    public GetBhuInfoListQuery(string Search, int PageSize, int Page)
    {
        this.Search = Search;
        this.PageSize = PageSize;
        this.Page = Page;
    }
}