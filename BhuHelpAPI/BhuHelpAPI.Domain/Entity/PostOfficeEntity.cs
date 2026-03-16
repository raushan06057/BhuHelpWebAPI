namespace BhuHelpAPI.Domain.Entity;

[Table(CommonFields.PostOffice)]
public class PostOfficeEntity : BaseEntity
{
    public string? Name { get; set; }
    public string? Pin { get; set; }
    [ForeignKey(CommonFields.District)]
    public long DistrictId { get; set; }
    
    // Navigation Property
    public virtual DistrictEntity District { get; set; }

    public virtual ICollection<BhuInfoEntity> BhuInfos { get; set; }
}
