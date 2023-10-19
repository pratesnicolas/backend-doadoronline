using System.ComponentModel.DataAnnotations;

namespace DoadorOnline.Domain;

public enum BloodType : int
{
    [Display(Name = "A")]
    A = 1,
    [Display(Name = "B")]
    B = 2,
    [Display(Name = "AB")]
    AB = 3,
    [Display(Name = "O")]
    O = 4
}

