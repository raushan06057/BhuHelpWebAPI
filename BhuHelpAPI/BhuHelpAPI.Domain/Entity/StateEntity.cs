namespace BhuHelpAPI.Domain.Entity;

public class StateEntity:BaseEntity
{
    public string? Name { get; set; }
    [ForeignKey(CommonFields.Country)]
    public long CountryId { get; set; }
    // Navigation Properties
    public virtual CountryEntity Country { get; set; }
    public virtual ICollection<DistrictEntity> Districts { get; set; }
}
