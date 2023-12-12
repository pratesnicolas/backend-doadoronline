

namespace DoadorOnline.Application;

public class DonatorHistoryViewModel
{
    public string Nome { get; set; }

    public IEnumerable<DonationViewModel> Donations { get; set; }

}
