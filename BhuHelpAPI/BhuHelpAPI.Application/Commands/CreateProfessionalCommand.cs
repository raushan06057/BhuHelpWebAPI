namespace BhuHelpAPI.Application.Commands;

public class CreateProfessionalCommand : IRequest<ResponseModel>
{
    public string Name { get; set; }
    public string Description { get; set; }
    [JsonIgnore]
    public string? CreatedBy { get; set; }
}