namespace BhuHelpAPI.Domain.Entity;

[Table(CommonFields.ChildInfo)]
public class ChildInfoEntity : BaseEntity
{
    [ForeignKey(CommonFields.BhuInfo)]
    public long? BhuInfoId { get; set; }
    public virtual BhuInfoEntity BhuInfo { get; set; }

    public string? Name { get; set; }
    public string? Address { get; set; }

    [ForeignKey(CommonFields.Professional)]
    public long? ProfessionId { get; set; }
    public virtual ProfessionalEntity Professional { get; set; }
}