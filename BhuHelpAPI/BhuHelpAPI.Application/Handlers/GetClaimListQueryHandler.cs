namespace BhuHelpAPI.Application.Handlers;

public class GetClaimListQueryHandler : IRequestHandler<GetClaimListQuery, ResponseModel>
{
    private readonly IClaimRepository repository;
    public GetClaimListQueryHandler(IClaimRepository repository)
    {
        this.repository = repository;
    }
    public async Task<ResponseModel> Handle(GetClaimListQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var query = repository.GetQueryAsync();

        if (!string.IsNullOrEmpty(request.Search))
            query = query.Where(u => u.ClaimType.Contains(request.Search) || u.ClaimValue.Contains(request.Search));

        var totalCount = query.Count();

        List<ClaimEntity> list = query
                    .OrderBy(u => u.ClaimType)
                    .OrderByDescending(mod => mod.Id)
                    .Skip(request.Page * request.PageSize)
                    .Take(request.PageSize)
                    .ToList();
        if (list.Count > 0)
        {
            GetClaimListResponse listResponse = new();
            listResponse.Claims = list;
            listResponse.TotalCount = totalCount;
            responseModel.Success = true;
            responseModel.Data = listResponse;
        }
        return responseModel;
    }
}
