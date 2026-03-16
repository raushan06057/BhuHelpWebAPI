namespace BhuHelpAPI.Infrastructure.Repositories;

public class DistrictRepository : RepositoryBase<DistrictEntity>, IDistrictRepository
{
    public DistrictRepository(ApplicationDbContext context) : base(context)
    {
    }
}
