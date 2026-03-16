namespace BhuHelpAPI.Application.Handlers;

public class UpdateBhuInfoCommandHandler : IRequestHandler<UpdateBhuInfoCommand, ResponseModel>
{
    private readonly ILogger<UpdateBhuInfoCommandHandler> logger;
    private IMapper mapper;
    private readonly IBhuInfoRepository repository;
    public UpdateBhuInfoCommandHandler(ILogger<UpdateBhuInfoCommandHandler> logger, IMapper mapper, IBhuInfoRepository repository)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.repository = repository;
    }
    public async Task<ResponseModel> Handle(UpdateBhuInfoCommand request, CancellationToken cancellationToken)
    {
        ResponseModel response = new();
        var entity = mapper.Map<BhuInfoEntity>(request);
        var updateBhuInfo = await repository.UpdateAsync(entity);
        if (updateBhuInfo.Id != 0) 
        {
            response.Success = true;
            response.Data = updateBhuInfo;
            response.Message = CommonResource.RecordSavedSuccessfully;
        }
        return response;
    }
}
