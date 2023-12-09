

namespace DoadorOnline.Application;
public class CampaignDetailsViewModel
{
    public string CampaignId { get; set; }
    public string DoneeName { get; set; }
    public int DoneeAge { get; set; }
    public string DonationPlace { get; set; }
    public string BloodType { get; set; }
    public string RHFactorType { get; set; }

    public string Base64Image { get; set; }

    public CampaignDetailsViewModel(string campaignId,
                                    string doneeName,
                                    int doneeAge,
                                    string donationPlace,
                                    string bloodType,
                                    string rHFactorType,
                                    string base64Image)
    {
        CampaignId = campaignId;
        DoneeName = doneeName;
        DoneeAge = doneeAge;
        DonationPlace = donationPlace;
        BloodType = bloodType;
        RHFactorType = rHFactorType;
        Base64Image = base64Image;
    }

}

