using DoadorOnline.Domain;

namespace DoadorOnline.Application;

public class UserDetailsViewModel
{
  
    public PersonalDataViewModel PersonalData { get; set; }
    public List<AddressViewModel> Addresses { get; set; }
    public DonationOptionsViewModel DonationOptions { get; set; }
    
    public List<DonationViewModel> DonationsHistory { get; set; }

    public UserDetailsViewModel(PersonalDataViewModel personalData,
                                List<AddressViewModel> addresses,
                                DonationOptionsViewModel donationOptions,
                                List<DonationViewModel> donationsHistory)
    {
        PersonalData = personalData;
        Addresses = addresses;
        DonationOptions = donationOptions;
        DonationsHistory = donationsHistory;
    }
}
