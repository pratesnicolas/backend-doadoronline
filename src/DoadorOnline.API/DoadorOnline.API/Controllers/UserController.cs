using DoadorOnline.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DoadorOnline.API.Controllers;

[Route("api/v1/users")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ITokenService _tokenService;
    private readonly IDonationQueries _donationQueries;
    public UserController(IMediator mediator,
                          ITokenService tokenService,
                          IDonationQueries donationQueries)
    {
        _mediator = mediator;
        _tokenService = tokenService;
        _donationQueries = donationQueries;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsersAsync([FromQuery] GetUserRequestDTO paramsDTO)
    {
        var result = await _donationQueries.GetDonators(paramsDTO);
        return Ok(result);
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserAsync([FromRoute] string userId)
    {
        var user = await _donationQueries.GetUserDetails(userId);
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserCommand command)
    {
        await this._mediator.Send(command);
        return Ok();
    }

    [HttpPost("password-recovery")]
    public async Task<IActionResult> RecoverPassword([FromBody] PasswordRecoveryCommand command)
    {
        await this._mediator.Send(command);
        return Ok();
    }

    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
    {
        await this._mediator.Send(command);
        return Ok();
    }

    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate([FromBody] AuthenticateUserCommand command)
    {
        var message = await this._mediator.Send(command);
        if (!message.IsValid)
            return BadRequest();

        var jwt = await _tokenService.GenerateToken(command.Email);
        return Ok(jwt);
    }

    [HttpPost("{userId}/donation")]
    public async Task<IActionResult> AddDonation([FromBody] AddDonationCommand command, [FromRoute] string userId)
    {
        command.UserId = userId;
        var message = await this._mediator.Send(command);
        return Ok(message);
    }

    [HttpGet("{userId}/donations")]
    public async Task<IActionResult> GetUserDonations([FromRoute] string userId)
    {
        var donations = await _donationQueries.GetUserDonations(userId);
        return Ok(donations);
    }

    [HttpPut("{userId}/personal-data")]
    public async Task<IActionResult> PutUserPersonalData([FromBody] UpdatePersonalDataCommand command, [FromRoute] string userId)
    {
        command.UserId = userId;
        var message = await this._mediator.Send(command);
        return Ok(message);
    }

    [HttpPut("{userId}/address")]
    public async Task<IActionResult> PutUserAddress([FromRoute] string userId, [FromBody] UpdateAddressCommand command)
    {
        command.UserId = userId;
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{userId}/donation-options")]
    public async Task<IActionResult> PutUserDonationOptions([FromRoute] string userId, [FromBody] UpdateDonationOptionsCommand command)
    {
        command.UserId =userId;
        var message = await this._mediator.Send(command);
        return Ok(message);
    }

}
