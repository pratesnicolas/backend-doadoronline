
using DoadorOnline.Domain;

namespace DoadorOnline.Application
{
    public interface IDonationQueries
    {
        Task<IEnumerable<DonationViewModel>> GetUserDonations(string userId);
        Task<IEnumerable<DonatorViewModel>> GetDonators(GetUserRequestDTO request);

        Task<IEnumerable<CampaignViewModel>> GetCampaigns(string name, BloodType? bloodtype, RHFactorType? rhFactor);
        Task<IEnumerable<CampaignViewModel>> GetCrouselCampaigns();
        Task<CampaignDetailsViewModel> GetCampaign(string campaignId);
    }
}