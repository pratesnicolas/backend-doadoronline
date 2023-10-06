using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace DoadorOnline.Domain;

public class User : IdentityUser
{
    public ValidationResult ValidationResult { get; set; } = new ValidationResult();
    public string Name { get; set; }

    //Refator to ObjectValue Address.
    //public Adress Adress 
    public string Adress { get; set; }
    public DateTime BirthDate { get; set; }
    public GenderEnum Gender { get; set; }
    public BloodType BloodType { get; set; }
    public int Points { get; set; }
    public string Cpf { get; set; }
    public string Cnpj { get; set; } 
 
    public User() { }

    public User(string name,
                GenderEnum gender,
                string cpf,
                string cnpj,
                BloodType bloodType)
    {
        Name = name;
        Gender = gender;
        Cpf = cpf;
        Cnpj = cnpj;
        BloodType = bloodType;
    }

    public static class Factory
    {
        public static User NewUser(string name,
                                   GenderEnum gender,
                                   string cpf,
                                   string cnpj,
                                   BloodType bloodType)
        {
            return new(name,
                       gender,
                       cpf,
                       cnpj,
                       bloodType);
        }
    }
}
