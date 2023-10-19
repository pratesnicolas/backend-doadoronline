namespace DoadorOnline.Domain;

public class Address : Entity
{
    public string DonatorId { get; private set; }
    public string Street { get; private set; }
    public string District { get; private set; }
    public string Number { get; private set; }
    public string Country { get; set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }

    public virtual Donator User { get; set; }

    public Address(string donatorId,
                   string street,
                   string district,
                   string number,
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
        Country = country;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    public static class Factory
    {
        public static Address NewAddress(string donatorId,
                                         string street,
                                         string district,
                                         string number,
                                         string country,
                                         string city,
                                         string state,
                                         string zipCode)

        {
            return new(donatorId,
                       street,
                       district,
                       number,
                       country,
                       city,
                       state,
                       zipCode);
        }

    }
}
