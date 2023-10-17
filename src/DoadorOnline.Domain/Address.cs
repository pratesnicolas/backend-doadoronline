namespace DoadorOnline.Domain;

public class Address : Entity
{
    public string UserId { get; set; }
    public string Street { get; set; }
    public string District { get; set; }
    public string Number { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    
    public User User { get; set; }

    public Address(string userId,
                   string street,
                   string district,
                   string number,
                   string country,
                   string city,
                   string state,
                   string zipCode)
    {
        UserId = userId;
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
        public static Address NewAddress(string userId,
                                         string street,
                                         string district,
                                         string number,
                                         string country,
                                         string city,
                                         string state,
                                         string zipCode)
        {
            return new(userId,
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
