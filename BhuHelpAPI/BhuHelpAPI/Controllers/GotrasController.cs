namespace BhuHelpAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GotrasController : ControllerBase
{
    private readonly IMediator mediator;

    public GotrasController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    [AuthAttribute(CommonFields.Gotras, CommonFields.AddGotra)]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> AddGotra([FromBody] CreateGotraCommand model)
    {
        model.CreatedBy =Convert.ToString(HttpContext.Items[CommonFields.UserId]);
        var result = await mediator.Send(model);
        return Ok(result);
    }

    // GET api/Gotras
    [HttpGet]
    [AuthAttribute(CommonFields.Gotras, CommonFields.GetGotraList)]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Get()
    {
        var query = new GetGotraListQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet(CommonFields.GetSearchGotras)]
    [AuthAttribute(CommonFields.Gotras, CommonFields.GetSearchGotras)]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetSearchGotras(
        int page = 0,
        int pageSize = 10,
        string search = "")
    {
        var query = new GetGotraListSearchQuery(search, pageSize, page);
        var result = await mediator.Send(query);
        return Ok(result);
    }
}