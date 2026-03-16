namespace BhuHelpAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthsController : ControllerBase
{
    private IMediator mediator;
    public AuthsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    [AuthAttribute(CommonFields.Auths, CommonFields.AddUser)]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> AddUser([FromBody] CreateApplicationUserCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpPost(CommonFields.Login)]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Login([FromBody] LoginCommand model)
    {
        try
        {
            var result = await mediator.Send(model);
            return Ok(result);
        }
        catch (Exception ex)
        {

            throw;
        }
       
    }

    [HttpPut]
    [AuthAttribute(CommonFields.Auths, CommonFields.UpdateUser)]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Update([FromBody] UpdateApplicationUserCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpGet(CommonFields.UserDetails)]
    [AuthAttribute(CommonFields.Auths, CommonFields.UserDetails)]
    public async Task<ActionResult> Get(string userId)
    {
        GetUserDetailsByIdQuery model = new(userId);
        var result = await mediator.Send(model);
        return Ok(result);
    }
}