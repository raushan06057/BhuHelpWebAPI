namespace BhuHelpAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase
{
    private readonly ILogger<RolesController> logger;
    private readonly IMediator mediator;
    public RolesController(ILogger<RolesController> logger, IMediator mediator)
    {
        this.logger = logger;
        this.mediator = mediator;
    }

    [HttpPost]
    [AuthAttribute(CommonFields.Auths, CommonFields.AddRole)]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> AddRole([FromBody] CreateApplicationRoleCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    [AuthAttribute(CommonFields.Auths, CommonFields.UpdateUser)]
    public async Task<ActionResult> UpdateRole([FromBody] UpdateApplicationRoleCommand model)
    {
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    [AuthAttribute(CommonFields.Auths, CommonFields.DeleteRole)]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> DeleteRole(string id)
    {
        DeleteApplicationRoleCommand model = new() { Id = id };
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpGet("{id}", Name = CommonFields.GetRole)]
    [AuthAttribute(CommonFields.Auths, CommonFields.GetRole)]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetRoleById(string id)
    {
        var query = new GetApplicationRoleByIdQuery(id);
        var result = await mediator.Send(query);
        return Ok(result);
    }
}
