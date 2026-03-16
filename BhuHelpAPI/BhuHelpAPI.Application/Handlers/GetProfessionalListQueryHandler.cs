namespace BhuHelpAPI.Application.Handlers;

public class GetProfessionalListQueryHandler : IRequestHandler<GetProfessionalListQuery, ResponseModel>
{
    private readonly IProfessionalRepository repository;
    public GetProfessionalListQueryHandler(IProfessionalRepository repository)
    {
        this.repository = repository;
    }
    public async Task<ResponseModel> Handle(GetProfessionalListQuery request, CancellationToken cancellationToken)
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
