namespace BhuHelpAPI.Application.Handlers;

public class GetUserDetailsByIdQueryHandler : IRequestHandler<GetUserDetailsByIdQuery, ResponseModel>
{
    private readonly IUserRepository repository;

    public GetUserDetailsByIdQueryHandler(IUserRepository repository)
    {
        this.repository = repository;
    }

    public async Task<ResponseModel> Handle(GetUserDetailsByIdQuery request, CancellationToken cancellationToken)
    {
        var userDetails = await repository.GetAsync(request.id);

        if (userDetails == null)
        {
            throw new UserDetailsNotFoundException(nameof(request), request.id);
        }
        return userDetails;
    }
}