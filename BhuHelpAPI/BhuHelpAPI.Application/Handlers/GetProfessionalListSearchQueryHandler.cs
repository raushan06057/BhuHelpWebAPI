namespace BhuHelpAPI.Application.Handlers;

public class GetProfessionalListSearchQueryHandler : IRequestHandler<GetProfessionalListSearchQuery, ResponseModel>
{
    private readonly IProfessionalRepository repository;
    public GetProfessionalListSearchQueryHandler(IProfessionalRepository repository)
    {
        this.repository = repository;
    }
    public async Task<ResponseModel> Handle(GetProfessionalListSearchQuery request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var query = repository.GetQueryAsync();

        if (!string.IsNullOrEmpty(request.Search))
            query = query.Where(u => u.Name.Contains(request.Search));

        var totalCount = query.Count();

        List<ProfessionalEntity> list = query
                    .OrderBy(u => u.Name)
                    .OrderByDescending(mod => mod.Id)
                    .Skip(request.Page * request.PageSize)
                    .Take(request.PageSize)
                    .ToList();
        if (list.Count > 0)
        {
            GetProfessionalListSearchQueryResponse listResponse = new();
            listResponse.Professionals = list;
            listResponse.TotalCount = totalCount;
            responseModel.Success = true;
            responseModel.Data = listResponse;
        }
        return responseModel;
    }
}