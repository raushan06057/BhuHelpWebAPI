namespace BhuHelpAPI.Domain.Entity;

[Table(CommonFields.District)]
public class DistrictEntity : BaseEntity
{
    public string? Name { get; set; }
    public long? StateId { get; set; }

    // Navigation Properties
    public virtual StateEntity State { get; set; }
    public virtual ICollection<PostOfficeEntity> PostOffices { get; set; }
}
