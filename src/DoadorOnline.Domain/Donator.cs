namespace DoadorOnline.Domain;

public class Donator : Entity
{

    public string UserId { get; set; }
    public BloodType BloodType { get; set; }
    public int Points { get; set; }

    public User User { get; set; }

    public Donator() { }

    public Donator(string userId, BloodType bloodType)
    {
        UserId = userId;
        BloodType = bloodType;
    }

    public void AddPoints(int newPoints)
    {
        Points += newPoints;
    }

    public static class Factory
    {
        public static Donator NewDonator(string userId,BloodType bloodType)
            => new(userId,bloodType);
    }
}
