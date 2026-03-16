namespace BhuHelpAPI.Application.Handlers;

public class GetGotraListSearchQueryHandler : IRequestHandler<GetGotraListSearchQuery, ResponseModel>
{
    private readonly IGotrasRepository repository;
    public GetGotraListSearchQueryHandler(IGotrasRepository repository)
    {
        this.repository = repository;
    }

    public async Task<ResponseModel> Handle(GetGotraListSearchQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var query = repository.GetQueryAsync();

        if (!string.IsNullOrEmpty(request.Search))
            query = query.Where(u => u.Name.Contains(request.Search));

        var totalCount = query.Count();

        List<GotraEntity> list = query
                    .OrderBy(u => u.Name)
                    .OrderByDescending(mod => mod.Id)
                    .Skip(request.Page * request.PageSize)
                    .Take(request.PageSize)
                    .ToList();
        if (list.Count > 0)
        {
            GetGotraListSearchQueryResponse listResponse = new();
            listResponse.Gotras = list;
            listResponse.TotalCount = totalCount;
            responseModel.Success = true;
            responseModel.Data = listResponse;
        }
        return responseModel;
    }
}