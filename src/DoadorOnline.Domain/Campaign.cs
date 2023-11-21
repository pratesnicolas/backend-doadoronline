namespace DoadorOnline.Domain;

public class Campaign : Entity
{
    public string DonatorId { get; set; }
    public virtual Donator User { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string DoneeName { get; set; }

    public string DonationPlace { get; set; }
    public BloodType DoneeBloodType { get; set; }
    public RHFactorType DoneeRhFactor { get; set; }
    public DateTime DoneeBirthDate { get; set; }
    public string Base64Image { get; set; }

    public Campaign() { }
    public Campaign(string donatorId,
                    string doneeName,
                    string donationPlace,
                    BloodType doneeBloodType,
                    DateTime doneeBirthDate,
                    RHFactorType doneeFactorType,
                    string base64Image)
    {
        base.Id = Guid.NewGuid().ToString();
        DonatorId = donatorId;
        DoneeName = doneeName;
        DonationPlace = donationPlace;
        DoneeBloodType = doneeBloodType;
        DoneeBirthDate = doneeBirthDate;
        DoneeRhFactor = doneeFactorType;
        ExpirationDate = DateTime.Now.AddDays(15);
        Base64Image = base64Image;
    }

    public static class Factory
    {
        public static Campaign NewCampaign(string donatorId,
                                           string doneeName,
                                           string donationPlace,
                                           BloodType doneeBloodType,
                                           DateTime doneeBirthDate,
                                           RHFactorType doneeRHFactor,
                                           string base64image)
        {
            return new(donatorId,
                       doneeName,
                       donationPlace,
                       doneeBloodType,
                       doneeBirthDate,
                       doneeRHFactor,
                       base64image);
        }
    }
}
