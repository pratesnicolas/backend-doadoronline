namespace DoadorOnline.Application;
public class DonatorViewModel
{
    public string Name { get; set; }
    public string Cpf { get; set; }
    public DateTime BirthDate { get; set; }
    public string BloodType { get; set; }
    public bool IsBloodDonator { get; set; }
    public bool IsMarrowDonator { get; set; }
    public bool IsOrganDonator { get; set; }

    public DonatorViewModel(string name,
                            string cpf,
                            DateTime birthDate,
                            string bloodType,
                            bool isBloodDonator,
                            bool isMarrowDonator,
                            bool isOrganDonator)
    {
        Name = name;
        Cpf = cpf;
        BirthDate = birthDate;
        BloodType = bloodType;
        IsBloodDonator = isBloodDonator;
        IsMarrowDonator = isMarrowDonator;
        IsOrganDonator = isOrganDonator;
    }
}
