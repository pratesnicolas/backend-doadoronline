using DoadorOnline.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DoadorOnline.API.Controllers;

[Route("api/v1/users")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    => _mediator = mediator;


    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserCommand command)
    {
        await this._mediator.Send(command);
        return Ok();
    }
    //Password Recovery

    //Password Reset
}
