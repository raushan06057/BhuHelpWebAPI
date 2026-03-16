namespace BhuHelpAPI.Domain.Entity;

[Table(CommonFields.BhuInfo)]
public class BhuInfoEntity : BaseEntity
{
    public string? Name { get; set; }
    public DateTime? DOB { get; set; }
    public int? Age { get; set; }

    [ForeignKey(CommonFields.Professional)]
    public long? ProfessionalId { get; set; }
    public virtual ProfessionalEntity Professional { get; set; }

    [ForeignKey(CommonFields.Gotra)]
    public long GotraId {  get; set; }
    public virtual GotraEntity Gotra { get; set; }

    public string? Land { get; set; }
    public string? MobileNumber { get; set; }
    public string? Address { get; set; }
    public string? Village { get; set; }

    [ForeignKey(CommonFields.PostOffice)]
    public long PostOfficeId { get; set; }
    public virtual PostOfficeEntity PostOffice { get; set; }

    public string? PoliceStation { get; set; }

    [ForeignKey(CommonFields.District)]
    public long DistrictId { get; set; }
    public virtual DistrictEntity District { get; set; }

    public int? Child { get; set; }
    public int? UnmarriedChild { get; set; }

    public virtual ICollection<ChildInfoEntity> ChildInfos { get; set; }
}