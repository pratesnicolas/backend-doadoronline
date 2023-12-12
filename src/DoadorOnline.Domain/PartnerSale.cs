namespace DoadorOnline.Domain;

public class PartnerSale : Entity
{ 
    public string DonatorId { get; private set; }
    public virtual Donator User { get; private set; }
    public string SaleName { get; private set; }
    public string Description { get; private set; } 
    public int Points { get; private set; }
}
