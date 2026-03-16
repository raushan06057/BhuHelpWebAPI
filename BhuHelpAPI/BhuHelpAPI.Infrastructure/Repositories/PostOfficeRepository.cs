namespace BhuHelpAPI.Infrastructure.Repositories;

public class PostOfficeRepository : RepositoryBase<PostOfficeEntity>, IPostOfficeRepository
{
    public PostOfficeRepository(ApplicationDbContext context) : base(context)
    {
    }
}
