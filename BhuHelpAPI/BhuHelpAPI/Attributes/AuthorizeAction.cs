using Microsoft.AspNetCore.Mvc.Filters;

namespace BhuHelpAPI.Attributes;

public class AuthorizeAction : IAuthorizationFilter
{
    private readonly string controller;
    private readonly string actionName;
    public AuthorizeAction(string controller, string actionName)
    {
        this.controller = controller;
        this.actionName = actionName;
    }
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        string? userId = Convert.ToString(context.HttpContext.Items[CommonFields.UserId]);
        if (string.IsNullOrEmpty(userId))
        {
            var result = new 
            {
                Success=false,
                Message= CommonResource.PermissionDenined,
            };
            context.Result = new JsonResult(result);
        }
        //switch (actionName)
        //{
        //    case "Index":
        //        if (!_roleType.Contains("admin")) context.Result = new JsonResult("Permission denined!");
        //        break;
        //}
    }
}
