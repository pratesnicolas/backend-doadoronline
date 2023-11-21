namespace DoadorOnline.Application;

public class DonationViewModel
{
    public string DonationType { get; set; }
    public string Hospital { get; set; }
    public DateTime DonationDate { get; set; }
    public int PointsEarned { get; set; }

    public DonationViewModel(string donationType,
                             string hospital,
                             DateTime donationDate,
                             int pointsEarned)
    {
        DonationType = donationType;
        Hospital = hospital;
        DonationDate = donationDate;
        PointsEarned = pointsEarned;
    }
}
