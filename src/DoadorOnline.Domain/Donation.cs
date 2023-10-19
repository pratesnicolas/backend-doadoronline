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

    //EF
    public Donation() { }

    public Donation(string donatorId,
                    DonationType donationType,
                    DateTime dateCreated,
                    string ipAddress,
                    int pointsEarned)
                    
    {
        base.Id = Guid.NewGuid().ToString();
        DonatorId = donatorId;
        DonationType = donationType;
        DateCreated = dateCreated;
        IpAddress = ipAddress;
        PointsEarned = pointsEarned;
    }
}
