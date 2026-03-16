namespace BhuHelpAPI.Application.Handlers;

public class CreateGotraCommandHandler : IRequestHandler<CreateGotraCommand, ResponseModel>
{
    private readonly IGotrasRepository repository;
    private IMapper mapper;
    public CreateGotraCommandHandler(IGotrasRepository repository,IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
   
    public async Task<ResponseModel> Handle(CreateGotraCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name)) { 
            throw new GotrasNameNotFoundException(request.Name,null);
        }
        
        var isNameExists = await repository.GetQueryAsync().AnyAsync(mod=>mod.Name.ToLower() == request.Name.ToLower());
        if (isNameExists) { 
            throw new GotrasNameAlreadyFoundException(request.Name,null);
        }
        var gotraModel = mapper.Map<GotraEntity>(request);
        gotraModel.CreatedOn= DateTime.Now;
        gotraModel.CreatedOnUtc= DateTime.UtcNow;
        var result = await repository.AddAsync(gotraModel);
        ResponseModel responseModel = new();
        if (result.Id != 0)
        {
            responseModel.Success = true;
            responseModel.Data = result;
            responseModel.Message = CommonResource.RecordSavedSuccessfully;
        }
        return responseModel;
    }
}
