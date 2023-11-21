
namespace DoadorOnline.Domain;

public class DonationIntention : Entity
{
    public string DonatorId { get; set; }   
    public DonationType DonationType { get; set; }

    //EF Relationship
    /*public virtual Donator User { get; set; }*/

    //EF
    public DonationIntention() {}
    public DonationIntention(string donatorId,
                             DonationType donationType)
    {
        base.Id = Guid.NewGuid().ToString();
        DonatorId = donatorId;
        DonationType = donationType;
    }

    public static class Factory
    {
        public static DonationIntention NewDonationIntention(string donatorId,
                                                             DonationType donationType)
        {
            return new(donatorId, donationType);
        }
    }
}
