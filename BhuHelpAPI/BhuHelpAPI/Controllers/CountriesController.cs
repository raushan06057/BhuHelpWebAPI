namespace BhuHelpAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
    private IMediator mediator;
    public CountriesController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpGet(Name = CommonFields.GetCountryList)]
    [AuthAttribute(CommonFields.Auths, CommonFields.GetCountryList)]
    [ProducesResponseType(typeof(ResponseModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Get()
    {
        var query = new GetCountryListQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }
}
