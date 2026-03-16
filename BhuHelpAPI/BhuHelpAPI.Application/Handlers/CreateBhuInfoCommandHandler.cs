namespace BhuHelpAPI.Application.Handlers;

public class CreateBhuInfoCommandHandler : IRequestHandler<CreateBhuInfoCommand, ResponseModel>
{
    private IBhuInfoRepository repository;
    private IMapper mapper;
    private readonly ILogger<CreateBhuInfoCommandHandler> logger;
    public CreateBhuInfoCommandHandler(IBhuInfoRepository repository,IMapper mapper,ILogger<CreateBhuInfoCommandHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<ResponseModel> Handle(CreateBhuInfoCommand request, CancellationToken cancellationToken)
    {
        ResponseModel responseModel = new();
        var bhuInfoEntity = mapper.Map<BhuInfoEntity>(request);
        var generateBhuInfo = await repository.AddAsync(bhuInfoEntity);
        if (generateBhuInfo.Id !=0) 
        {
            responseModel.Success=true;
            responseModel.Data = generateBhuInfo;
            responseModel.Message = CommonResource.RecordSavedSuccessfully;
        }
        return responseModel;
    }
}
