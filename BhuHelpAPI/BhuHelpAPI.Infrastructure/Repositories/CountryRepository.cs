namespace BhuHelpAPI.Infrastructure.Repositories;

public class CountryRepository : RepositoryBase<CountryEntity>, ICountryRepository
{
    public CountryRepository(ApplicationDbContext context) : base(context)
    {
    }
}
