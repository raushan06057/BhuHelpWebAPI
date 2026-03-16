namespace BhuHelpAPI.Application.Handlers;

public class GetBhuInfoListHandler : IRequestHandler<GetBhuInfoListQuery, ResponseModel>
{
    private readonly IBhuInfoRepository repository;
    public GetBhuInfoListHandler(IBhuInfoRepository repository)
    {
        this.repository = repository;
    }
    public async Task<ResponseModel> Handle(GetBhuInfoListQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var query = repository.GetQueryAsync();

        if (!string.IsNullOrEmpty(request.Search))
            query = query.Where(u => u.Name.Contains(request.Search) || u.MobileNumber.Contains(request.Search));

        var totalCount = query.Count();

        List<BhuInfoEntity> list = query
                    .OrderBy(u => u.Name)
                    .OrderByDescending(mod=>mod.Id)
                    .Skip(request.Page * request.PageSize)
                    .Take(request.PageSize)
                    .ToList();
        if(list.Count > 0)
        {
            GetBhuInfoListResponse listResponse = new();
            listResponse.BhuInfos = list;
            listResponse.TotalCount = totalCount;
            responseModel.Success = true;
            responseModel.Data = listResponse;
        }
        return responseModel;
    }
}
