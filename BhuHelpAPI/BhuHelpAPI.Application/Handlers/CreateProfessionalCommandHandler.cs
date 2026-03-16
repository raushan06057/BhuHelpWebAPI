namespace BhuHelpAPI.Application.Handlers;

public class CreateProfessionalCommandHandler : IRequestHandler<CreateProfessionalCommand, ResponseModel>
{
    private readonly IProfessionalRepository repository;
    private readonly IMapper mapper;

    public CreateProfessionalCommandHandler(IProfessionalRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<ResponseModel> Handle(CreateProfessionalCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            throw new ProfessionalNameNotFoundException(request.Name, null);
        }

        if (string.IsNullOrWhiteSpace(request.Description))
        {
            throw new ProfessionalDescriptionNotFoundException(request.Description, null);
        }

        // 3️⃣ Check duplicate Name (case-insensitive & trim)
        var isExists = await repository.GetQueryAsync()
            .AnyAsync(p => p.Name.Trim().ToLower() == request.Name.Trim().ToLower(), cancellationToken);

        if (isExists)
        {
            throw new ProfessionalAlreadyExistsException(request.Name, null);
        }

        // 4️⃣ Map command -> entity
        var professionalEntity = mapper.Map<ProfessionalEntity>(request);
        professionalEntity.CreatedOn = DateTime.Now;
        professionalEntity.CreatedOnUtc = DateTime.UtcNow;
        professionalEntity.CreatedBy = request.CreatedBy;
        // 5️⃣ Insert into repository
        var result = await repository.AddAsync(professionalEntity);

        // 6️⃣ Prepare response
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