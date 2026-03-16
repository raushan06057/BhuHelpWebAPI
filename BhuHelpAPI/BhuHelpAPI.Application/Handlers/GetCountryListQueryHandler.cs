namespace BhuHelpAPI.Application.Handlers;

public class GetCountryListQueryHandler : IRequestHandler<GetCountryListQuery, ResponseModel>
{
    private readonly ICountryRepository repository;
    public GetCountryListQueryHandler(ICountryRepository repository)
    {
        this.repository = repository;
    }
    public async Task<ResponseModel> Handle(GetCountryListQuery request, CancellationToken cancellationToken)
    {
        ResponseModel response = new();
        var result = await repository.GetAsync();
        if (result != null)
        {
            response.Success = true;
            response.Data = result;
        }
        return response;
    }
}
