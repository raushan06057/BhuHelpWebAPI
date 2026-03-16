namespace BhuHelpAPI.Application.Exceptions;

public class GotrasNameAlreadyFoundException:ApplicationException
{
    public GotrasNameAlreadyFoundException(string name,string key):base($"Entity {name} - {key} is already found.")
    {
        
    }
}
