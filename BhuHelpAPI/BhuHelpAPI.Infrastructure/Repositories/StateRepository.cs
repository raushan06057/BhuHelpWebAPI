namespace BhuHelpAPI.Infrastructure.Repositories;

public class StateRepository : RepositoryBase<StateEntity>, IStateRepository
{
    public StateRepository(ApplicationDbContext context) : base(context)
    {
    }
}
