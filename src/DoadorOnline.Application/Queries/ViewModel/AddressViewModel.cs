namespace DoadorOnline.Application;
public class AddressViewModel
{
    public string ZipCode { get; set; }
    public string Street { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string Number { get; set; }
    public string AddressLine2 { get; set; }
    public string State { get; set; }

    public AddressViewModel(string zipCode,
                            string street,
                            string district,
                            string city,
                            string number,
                            string addressLine2,
                            string state)
    {
        ZipCode = zipCode;
        Street = street;
        District = district;
        City = city;
        Number = number;
        AddressLine2 = addressLine2;
        State = state;
    }
}

