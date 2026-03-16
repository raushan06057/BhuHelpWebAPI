namespace BhuHelpAPI.Application.Handlers;

public class GetBhuInfoByIdQueryHandler : IRequestHandler<GetBhuInfoByIdQuery, ResponseModel>
{
    private readonly IBhuInfoRepository repository;
    private ILogger<GetBhuInfoByIdQuery> logger;
    public GetBhuInfoByIdQueryHandler(IBhuInfoRepository repository, ILogger<GetBhuInfoByIdQuery> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<ResponseModel> Handle(GetBhuInfoByIdQuery request, CancellationToken cancellationToken)
    {
        ResponseModel response = new();
        var result = await repository.GetAsync(request.id);
        if (result != null) 
        {
            response.Success = true;
            response.Data= result;
        }
        return response;
    }
}
