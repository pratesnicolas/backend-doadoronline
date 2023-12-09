using System.ComponentModel.DataAnnotations.Schema;

namespace DoadorOnline.Domain;

public class Donation : Entity
{
    public string DonatorId { get; set; }
    public DonationType DonationType { get; set; }
    public DateTime DateCreated { get; set; }
    public string IpAddress { get; set; }
    public int PointsEarned { get; set; }

    public virtual Donator User { get; set; }
    public string DonationPlace { get; set; }

    //EF
    public Donation() { }

    public Donation(string donatorId,
                    DonationType donationType,
                    string ipAddress,
                    int pointsEarned,
                    string donationPlace)
                    
    {
        base.Id = Guid.NewGuid().ToString();
        DonatorId = donatorId;
        DonationType = donationType;
        DateCreated = DateTime.Now;
        IpAddress = ipAddress;
        PointsEarned = pointsEarned;
        DonationPlace = donationPlace;
    }

    public static class Factory
    {
        public static Donation NewDonation(string donatorId,
                                    DonationType donationType,
                                    string ipAddress,
                                    int pointsEarned,
                                    string donationPlace)
        {
            return new(donatorId,
                       donationType,
                       ipAddress,
                       pointsEarned,
                       donationPlace);
        }
    }
}
