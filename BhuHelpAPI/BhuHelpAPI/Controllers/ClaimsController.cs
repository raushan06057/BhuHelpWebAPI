namespace BhuHelpAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClaimsController : ControllerBase
{
    private readonly IMediator mediator;
    public ClaimsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    [AuthAttribute(CommonFields.Claims, CommonFields.GetClaimList)]
    public async Task<ActionResult> Get(string Search, int PageSize, int Page)
    {
        var query = new GetClaimListQuery(Search, PageSize, Page);
        var result = await mediator.Send(query);
        return Ok(result);
    }
}
