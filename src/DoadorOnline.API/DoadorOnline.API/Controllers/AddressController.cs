using DoadorOnline.BrasilApiService;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DoadorOnline.API.Controllers
{
    [Route("api/v1/address")]
    public class AddressController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IBrasilApiService _brasilApiService;

        public AddressController(IMediator mediator,
                                 IBrasilApiService brasilApiService)
        {
            _mediator = mediator;
            _brasilApiService = brasilApiService;
        }

        [HttpGet("{cep:int}")]
        public async Task<IActionResult> CreateUserAsync(int cep)
        {
            var address = await this._brasilApiService.GetAddressByCep(cep);
            if (!address.IsSuccess)
            {
                return Problem(address.message);
            }
            return Ok(address);
        }
    }
}
