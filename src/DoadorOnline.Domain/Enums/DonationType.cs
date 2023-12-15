using System.ComponentModel.DataAnnotations;

namespace DoadorOnline.Domain;

public enum DonationType : int
{
    [Display(Name ="Sangue")]
    Blood = 1,
    [Display(Name = "Medula Óssea")]
    BoneMarrow = 2,
    [Display(Name = "Órgãos")]
    Organs = 3
}