using DoadorOnline.Domain;

namespace DoadorOnline.Application;

public class PersonalDataViewModel
{
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public GenderEnum Gender { get; set; }
    public string PhoneNumber { get; set; }

    public PersonalDataViewModel(string name,
                                 string cpf,
                                 string email,
                                 DateTime birthDate,
                                 GenderEnum gender,
                                 string phoneNumber)
    {
        Name = name;
        Cpf = cpf;
        Email = email;
        BirthDate = birthDate;
        Gender = gender;
        PhoneNumber = phoneNumber;
    }
}
