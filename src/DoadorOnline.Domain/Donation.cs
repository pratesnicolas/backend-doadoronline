namespace DoadorOnline.Domain;

public class Donation : Entity
{

    public string UserId { get; set; }
    public DonationType DonationType { get; set; }
    public DateTime DateCreated { get; set; }
    public string IpAdress { get; set; }

    public User User { get; set; }

    public Donation() { }

    public Donation(DonationType donationType,
                    DateTime dateCreated,
                    string ipAdress)
    {
        DonationType = donationType;
        DateCreated = dateCreated;
        IpAdress = ipAdress;
    }
}
