using DoadorOnline.Domain;

namespace DoadorOnline.Application;

public class CampaignViewModel
{
    public string CampaignId { get; set; }  
    public string DoneeName { get; set; }
    public int DoneeAge { get; set; }
    public string BloodType { get; set; }
    public string RHFactorType { get; set; }

    public CampaignViewModel(string campaignId,
                             string doneeName,
                             int doneeAge,
                             string bloodType,
                             string rHFactorType)
    {
        CampaignId = campaignId;
        DoneeName = doneeName;
        DoneeAge = doneeAge;
        BloodType = bloodType;
        RHFactorType = rHFactorType;
    }
}
