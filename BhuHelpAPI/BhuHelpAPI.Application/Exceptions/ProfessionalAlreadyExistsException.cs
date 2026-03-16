namespace BhuHelpAPI.Application.Exceptions;

public class ProfessionalAlreadyExistsException : ApplicationException
{
    public ProfessionalAlreadyExistsException(string name, string key) : base($"Entity {name} - {key} already exists.")
    {

    }
}