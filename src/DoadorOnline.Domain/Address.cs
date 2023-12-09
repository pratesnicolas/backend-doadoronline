namespace DoadorOnline.Domain;

public class Address : Entity
{
    public string DonatorId { get; private set; }
    public string Street { get; private set; }
    public string District { get; private set; }
    public string Number { get; private set; }
    public string AddressLine2 { get; private set; }
    public string Country { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }

    public virtual Donator User { get; set; }

    public Address(string donatorId,
                   string street,
                   string district,
                   string number,
                   string addressLine2,
                   string country,
                   string city,
                   string state,
                   string zipCode)

    {
        base.Id = Guid.NewGuid().ToString();
        DonatorId = donatorId;
        Street = street;
        District = district;
        Number = number;
        AddressLine2 = addressLine2;
        Country = country;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    public void UpdateAddress(string zipCode,
                              string street,
                              string district,
                              string number,
                              string addressLine2,
                              string city,
                              string state)
    {
        this.ZipCode = zipCode;
        this.Street = street;
        this.District = district;
        this.Number = number;
        this.AddressLine2 = addressLine2;
        this.City = city;
        this.State = state;
    }

    public static class Factory
    {
        public static Address NewAddress(string donatorId,
                                         string street,
                                         string district,
                                         string number,
                                         string addressLine2,
                                         string country,
                                         string city,
                                         string state,
                                         string zipCode)

        {
            return new(donatorId,
                       street,
                       district,
                       number,
                       addressLine2,
                       country,
                       city,
                       state,
                       zipCode);
        }

    }
}
