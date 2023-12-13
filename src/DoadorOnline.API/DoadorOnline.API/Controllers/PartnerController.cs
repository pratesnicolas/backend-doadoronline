using DoadorOnline.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DoadorOnline.API.Controllers;

[Route("api/v1/partners")]
public class PartnerController : Controller
{
    private readonly IMediator _mediator;

    public PartnerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePartnerAsync([FromForm] CreatePartnerCommand command)
    {
        var request = await _mediator.Send(command);
        return Ok(request);
    }
    
}
