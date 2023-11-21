
namespace DoadorOnline.Domain;

public class Donation : Entity
{
    public string DonatorId { get; set; }
    public virtual Donator User { get; set; }

    public string DonationPlace { get; set; }
    public DonationType DonationType { get; set; }
    public DateTime DateCreated { get; set; }
    public string IpAddress { get; set; }
    public int PointsEarned { get; set; }

    //EF
    public Donation() { }

    public Donation(string donatorId,
                    DonationType donationType,
                    string donationPlace,
                    DateTime dateCreated,
                    string ipAddress,
                    int pointsEarned)
                    
    {
        base.Id = Guid.NewGuid().ToString();
        DonatorId = donatorId;
        DonationType = donationType;
        DonationPlace = donationPlace;
        DateCreated = dateCreated;
        IpAddress = ipAddress;
        PointsEarned = pointsEarned;
    }
}
