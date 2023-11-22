using DoadorOnline.Application;
using DoadorOnline.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DoadorOnline.API.Controllers
{
    [Route("api/v1/campaigns")]
    public class CampaignsController : Controller
    {
        private readonly IDonationQueries _donationQueries;
        private readonly IMediator _mediator;

        public CampaignsController(IMediator mediator, IDonationQueries donationQueries)
        {
            _mediator = mediator;
            _donationQueries = donationQueries;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCampaignAsync([FromForm] CreateCampaignCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetCampaignsAsync(string name,
                                                           BloodType? bloodtype,
                                                           RHFactorType? rhFactor)
        {
            var campaigns = await _donationQueries.GetCampaigns(name, bloodtype, rhFactor);
            return Ok(campaigns);
        }

        [HttpGet("carrousel")]
        public async Task<IActionResult> GetCarouselCampaignsAsync()
        {
            var campaigns = await _donationQueries.GetCarouselCampaigns();
            return Ok(campaigns);
        }

        [HttpGet("{campaignId}")]
        public async Task<IActionResult> GetCampaign([FromRoute] string campaignId)
        {
            var campaigns = await _donationQueries.GetCampaign(campaignId);
            return Ok(campaigns);
        }
    }
}
