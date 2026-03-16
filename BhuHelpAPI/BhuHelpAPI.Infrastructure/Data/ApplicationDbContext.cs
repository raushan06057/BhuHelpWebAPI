namespace BhuHelpAPI.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public virtual DbSet<GotraEntity> Gotras { get; set; }
    public virtual DbSet<CountryEntity> Countries { get; set; }
    public virtual DbSet<StateEntity> States { get; set; }
    public virtual DbSet<DistrictEntity> Districts { get; set; }
    public virtual DbSet<PostOfficeEntity> PostOffices { get; set; }
    public virtual DbSet<ProfessionalEntity> Professionals { get; set; }
    public virtual DbSet<BhuInfoEntity> BhuInfos { get; set; }
    public virtual DbSet<ChildInfoEntity> ChildInfos { get; set; }
    public virtual DbSet<ClaimEntity> Claims { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<BhuInfoEntity>()
    .HasOne(b => b.PostOffice)
    .WithMany(p => p.BhuInfos)
    .HasForeignKey(b => b.PostOfficeId)
    .OnDelete(DeleteBehavior.Restrict);
    }
}