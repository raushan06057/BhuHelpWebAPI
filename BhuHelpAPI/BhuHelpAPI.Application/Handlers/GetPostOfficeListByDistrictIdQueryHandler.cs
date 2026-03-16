namespace BhuHelpAPI.Application.Handlers;

public class GetPostOfficeListByDistrictIdQueryHandler : IRequestHandler<GetPostOfficeListByDistrictIdQuery, ResponseModel>
{
    private readonly IPostOfficeRepository repository;
    public GetPostOfficeListByDistrictIdQueryHandler(IPostOfficeRepository repository)
    {
        this.repository = repository;
    }
    public async Task<ResponseModel> Handle(GetPostOfficeListByDistrictIdQuery request, CancellationToken cancellationToken)
    {
        ResponseModel response = new();
        var result = await repository.GetAsync(mod => mod.DistrictId == request.DistrictId);
        if (result != null)
        {
            response.Success = true;
            response.Data = result;
        }
        return response;
    }
}
