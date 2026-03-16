namespace BhuHelpAPI.Application.Handlers;

public class GetGotraListQueryHandler : IRequestHandler<GetGotraListQuery, ResponseModel>
{
    public readonly IGotrasRepository repository;

    public GetGotraListQueryHandler(IGotrasRepository repository)
    {
        this.repository = repository;
    }
    public async Task<ResponseModel> Handle(GetGotraListQuery request, CancellationToken cancellationToken)
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
