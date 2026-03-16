namespace BhuHelpAPI.Application.Handlers;

public class GetDistrictListByStateIdQueryHandler : IRequestHandler<GetDistrictListByStateIdQuery, ResponseModel>
{
    private readonly IDistrictRepository repository;
    public GetDistrictListByStateIdQueryHandler(IDistrictRepository repository)
    {
        this.repository = repository;
    }
    public async Task<ResponseModel> Handle(GetDistrictListByStateIdQuery request, CancellationToken cancellationToken)
    {
        ResponseModel response = new();
        var result = await repository.GetAsync(mod=>mod.StateId==request.StateId);
        if (result != null)
        {
            response.Success = true;
            response.Data = result;
        }
        return response;
    }
}
