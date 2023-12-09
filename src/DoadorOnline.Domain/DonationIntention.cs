
namespace DoadorOnline.Domain;

public class DonationIntention : Entity
{
    public string DonatorId { get; set; }
    public DonationType DonationType { get; set; }

    //EF Relationship
    /*public virtual Donator User { get; set; }*/

    //EF
    public DonationIntention() { }
    public DonationIntention(string donatorId,
                             DonationType donationType)
    {
        base.Id = Guid.NewGuid().ToString();
        DonatorId = donatorId;
        DonationType = donationType;
    }

    public static class Factory
    {
        public static DonationIntention NewBloodDonationIntention(string donatorId)
            => new(donatorId, DonationType.Blood);
        public static DonationIntention NewBoneMarrowDonationIntention(string donatorId)
           => new(donatorId, DonationType.BoneMarrow);
        public static DonationIntention NewOrgansDonationIntention(string donatorId)
          => new(donatorId, DonationType.Organs);
    }

}