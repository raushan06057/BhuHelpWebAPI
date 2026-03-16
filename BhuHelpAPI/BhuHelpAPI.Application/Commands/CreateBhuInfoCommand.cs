namespace BhuHelpAPI.Application.Commands;

public class CreateBhuInfoCommand:IRequest<ResponseModel>
{
    public string? Name { get; set; }
    public DateTime? DOB { get; set; }
    public int? Age { get; set; }
    public long? ProfessionalId { get; set; }
    public long GotraId { get; set; }
    public string? Land { get; set; }
    public string? MobileNumber { get; set; }
    public string? Address { get; set; }
    public string? Village { get; set; }
    public long PostOfficeId { get; set; }
    public string? PoliceStation { get; set; }
    public long DistrictId { get; set; }
    public int? Child { get; set; }
    public int? UnmarriedChild { get; set; }

    //public List<ChildInfoEntity> ChildInfos { get; set; }

}