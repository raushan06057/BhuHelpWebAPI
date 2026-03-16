namespace BhuHelpAPI.Application.Exceptions;

public class ProfessionalNameNotFoundException: ApplicationException
{
    public ProfessionalNameNotFoundException(string name,string key):base($"Entity {name} - {key} is not found.")
    {
        
    }
}
