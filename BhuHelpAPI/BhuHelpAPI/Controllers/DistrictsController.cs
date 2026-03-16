namespace BhuHelpAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DistrictsController : ControllerBase
{
    private IMediator mediator;
    public DistrictsController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpGet("{id}", Name = CommonFields.GetDistrictList)]
    [AuthAttribute(CommonFields.Auths, CommonFields.GetDistrictList)]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Get(long id)
    {
        var query = new GetDistrictListByStateIdQuery(id);
        var result = await mediator.Send(query);
        return Ok(result);
    }
}
