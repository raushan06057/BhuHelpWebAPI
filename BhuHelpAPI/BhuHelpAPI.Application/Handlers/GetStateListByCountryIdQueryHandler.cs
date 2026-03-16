namespace BhuHelpAPI.Application.Handlers;

public class GetStateListByCountryIdQueryHandler : IRequestHandler<GetStateListByCountryIdQuery, ResponseModel>
{
    private readonly IStateRepository repository;
    public GetStateListByCountryIdQueryHandler(IStateRepository repository)
    {
        this.repository = repository;
    }
    public async Task<ResponseModel> Handle(GetStateListByCountryIdQuery request, CancellationToken cancellationToken)
    {
        ResponseModel response = new();
        var result = await repository.GetAsync(mod=>mod.CountryId==request.CountryId);
        if (result != null)
        {
            response.Success = true;
            response.Data = result;
        }
        return response;
    }
}
