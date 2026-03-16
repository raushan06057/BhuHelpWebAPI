namespace BhuHelpAPI.Application.Commands;

public class CreateGotraCommand : IRequest<ResponseModel>
{
    public string Name { get; set; }
    [JsonIgnore]
    public string? CreatedBy { get; set; }
}
