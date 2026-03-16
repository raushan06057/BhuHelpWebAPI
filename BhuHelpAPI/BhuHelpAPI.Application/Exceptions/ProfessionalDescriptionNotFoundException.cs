namespace BhuHelpAPI.Application.Exceptions;

public class ProfessionalDescriptionNotFoundException : ApplicationException
{
    public ProfessionalDescriptionNotFoundException(string name, string key) : base($"Entity {name} - {key} is not found.")
    {

    }
}
