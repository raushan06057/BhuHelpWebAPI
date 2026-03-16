namespace BhuHelpAPI.Infrastructure.Repositories;

public class GotrasRepository : RepositoryBase<GotraEntity>, IGotrasRepository
{
    public GotrasRepository(ApplicationDbContext context) : base(context)
    {
    }
}
