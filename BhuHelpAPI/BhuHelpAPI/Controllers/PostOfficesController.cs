namespace BhuHelpAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostOfficesController : ControllerBase
{
    private IMediator mediator;
    public PostOfficesController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpGet("{id}", Name = CommonFields.GetPostOfficeList)]
    [AuthAttribute(CommonFields.Auths, CommonFields.GetPostOfficeList)]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Get(long id)
    {
        var query = new GetPostOfficeListByDistrictIdQuery(id);
        var result = await mediator.Send(query);
        return Ok(result);
    }
}
