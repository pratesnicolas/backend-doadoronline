namespace DoadorOnline.Domain;

public class PartnerSale : Entity
{ 
    public string DonatorId { get; private set; }
    public virtual Donator User { get; private set; }
    public string SaleName { get; private set; }
    public string Description { get; private set; } 
    public int Points { get; private set; }

    public PartnerSale() { }


    public PartnerSale(string donatorId,
                       string saleName,
                       string description,
                       int points)
    {
        base.Id = Guid.NewGuid().ToString();
        DonatorId = donatorId;
        SaleName = saleName;
        Description = description;
        Points = points;
    }
    

    public static class Factory
    {
        public static PartnerSale NewSale(string donatorId,
                                          string saleName,
                                          string description,
                                          int points)
        {
            return new(donatorId,
                       saleName,
                       description,
                       points);
        }

    }
}
