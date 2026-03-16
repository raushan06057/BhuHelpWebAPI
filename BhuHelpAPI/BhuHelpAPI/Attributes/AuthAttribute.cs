namespace BhuHelpAPI.Attributes;

public class AuthAttribute : TypeFilterAttribute
{
    public AuthAttribute(string controller, string actionName) : base(typeof(AuthorizeAction))
    {
        Arguments = new object[] {
            controller,
            actionName
        };
    }
}
