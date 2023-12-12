using DoadorOnline.Application;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoadorOnline.API.Controllers;

[Route("api/v1/sales")]
public class SalesController : Controller
{
    private readonly ISalesQueries _salesQueries;
    private readonly IMediator _mediator;
    public SalesController(ISalesQueries salesQueries, IMediator mediator)
    {
        _salesQueries = salesQueries;
        _mediator = mediator;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAllSales()
    {
        var sales = await _salesQueries.GetSales();
        return Ok(sales);
    }

    [HttpPost("{saleId}/use-points")]
    public async Task<IActionResult> UseSalePoints([FromRoute] string saleId, [FromBody] UseSalesPointsCommand command)
    {
        command.SaleId = saleId;
        var request = await _mediator.Send(command);
        return Ok(request);
    }

    [HttpGet("carousel")]
    public async Task<IActionResult> GetSalesCarousel()
    {
        var sales = await _salesQueries.GetCarouselSales();
        return Ok(sales);
    }

    [HttpDelete("{saleId}")]
    public async Task<IActionResult> DeleteSale([FromRoute] string saleId)
    {
        var command = new DeleteSaleCommand
        {
            SaleId = saleId
        };
        await _mediator.Send(command);
        return Ok(command);
    }
}
