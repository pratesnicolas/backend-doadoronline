

using DoadorOnline.Domain;

namespace DoadorOnline.Application;
public class DonationOptionsViewModel
{
    public bool IsOrganDonator { get; set; }
    public bool IsBloodDonator { get; set; }
    public BloodType BloodType { get; set; }
    public RHFactorType RHFactorType { get; set; }
    public bool IsBoneMarrowDonator { get; set; }

    public DonationOptionsViewModel(bool isOrganDonator,
                                    bool isBloodDonator,
                                    BloodType bloodType,
                                    RHFactorType rHFactorType,
                                    bool isBoneMarrowDonator)
    {
        IsOrganDonator = isOrganDonator;
        IsBloodDonator = isBloodDonator;
        BloodType = bloodType;
        RHFactorType = rHFactorType;
        IsBoneMarrowDonator = isBoneMarrowDonator;
    }
}

