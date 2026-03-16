namespace BhuHelpAPI.Infrastructure.Repositories;

public class BhuInfoRepository : RepositoryBase<BhuInfoEntity>, IBhuInfoRepository
{
    public BhuInfoRepository(ApplicationDbContext context) : base(context)
    {
    }
}
