namespace BhuHelpAPI.Infrastructure.Repositories;

public class ClaimRepository : RepositoryBase<ClaimEntity>, IClaimRepository
{
    public ClaimRepository(ApplicationDbContext context) : base(context)
    {
    }
}
