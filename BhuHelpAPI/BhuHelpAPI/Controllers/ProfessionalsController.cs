namespace BhuHelpAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfessionalsController : ControllerBase
{
    private IMediator mediator;
    public ProfessionalsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    [AuthAttribute(CommonFields.Professionals, CommonFields.AddProfessional)]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> AddProfessional([FromBody] CreateProfessionalCommand model)
    {
        model.CreatedBy = Convert.ToString(HttpContext.Items[CommonFields.UserId]);
        var result = await mediator.Send(model);
        return Ok(result);
    }

    [HttpGet(Name = CommonFields.GetProfessionalList)]
    [AuthAttribute(CommonFields.Professionals, CommonFields.GetProfessionalList)]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Get()
    {
        var query = new GetProfessionalListQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet(CommonFields.GetSearchProfessions)]
    [AuthAttribute(CommonFields.Professionals, CommonFields.GetSearchProfessions)]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetSearchProfessions(
        int page = 0,
        int pageSize = 10,
        string search = "")
    {
        var query = new GetProfessionalListSearchQuery(search, pageSize, page);
        var result = await mediator.Send(query);
        return Ok(result);
    }
}
