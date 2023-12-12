
using DoadorOnline.Domain;

namespace DoadorOnline.Application
{
    public interface IDonationQueries
    {
        Task<DonatorHistoryViewModel> GetUserDonations(string userId);
        Task<IEnumerable<DonatorViewModel>> GetDonators(GetUserRequestDTO request);
        Task<UserDetailsViewModel> GetUserDetails(string userId);

        Task<IEnumerable<CampaignViewModel>> GetCampaigns(string name, BloodType? bloodtype, RHFactorType? rhFactor);
        Task<IEnumerable<CampaignViewModel>> GetCarouselCampaigns();
        Task<CampaignDetailsViewModel> GetCampaign(string campaignId);
        Task<int> GetUserPoints(string userId);
    }
}