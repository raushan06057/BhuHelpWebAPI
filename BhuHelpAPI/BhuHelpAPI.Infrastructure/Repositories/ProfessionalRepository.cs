namespace BhuHelpAPI.Infrastructure.Repositories;

public class ProfessionalRepository : RepositoryBase<ProfessionalEntity>, IProfessionalRepository
{
    public ProfessionalRepository(ApplicationDbContext context) : base(context)
    {
    }
}
