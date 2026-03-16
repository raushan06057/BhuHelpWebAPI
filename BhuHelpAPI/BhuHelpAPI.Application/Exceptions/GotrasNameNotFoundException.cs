namespace BhuHelpAPI.Application.Exceptions;

public class GotrasNameNotFoundException:ApplicationException
{
    public GotrasNameNotFoundException(string name,string key):base($"Entity {name} - {key} is not found.")
    {
        
    }
}