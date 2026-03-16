namespace BhuHelpAPI.Application.Exceptions;

public class UserDetailsNotFoundException : ApplicationException
{
    public UserDetailsNotFoundException(string name, object key) : base($"Entity {name} - {key} is not found.")
    {

    }
}