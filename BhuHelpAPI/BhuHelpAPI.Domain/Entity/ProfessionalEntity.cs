namespace BhuHelpAPI.Domain.Entity;
[Table(CommonFields.Professional)]
public class ProfessionalEntity : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public virtual ICollection<BhuInfoEntity> BhuInfos { get; set; }
}
