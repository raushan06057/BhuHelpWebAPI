namespace BhuHelpAPI.Domain.Entity;

[Table(CommonFields.Gotra)]
public class GotraEntity : BaseEntity
{
    public string? Name { get; set; }
    public virtual ICollection<BhuInfoEntity> BhuInfos { get; set; }
}
