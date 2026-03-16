namespace BhuHelpAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatesController : ControllerBase
{
    private IMediator mediator;
    public StatesController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpGet("{id}", Name = CommonFields.GetStateList)]
    [AuthAttribute(CommonFields.Auths, CommonFields.GetStateList)]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Get(long id)
    {
        var query = new GetStateListByCountryIdQuery(id);
        var result = await mediator.Send(query);
        return Ok(result);
    }
}
