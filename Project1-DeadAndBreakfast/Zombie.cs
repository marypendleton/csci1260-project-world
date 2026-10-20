namespace DeadAndBreakfast
{
    public class Zombie : UndeadGuest, IFeedable
    {
        public Zombie(string guestId, string name, int yearsSinceDeath)
            : base(guestId, name, yearsSinceDeath)
        {
        }

        public override string Describe()
        {
            return $"{base.Describe()}, Kind: Zombie";
        }

        public override string GetAccommodationNeeds()
        {
            return "A ground-floor room with washable bedding.";
        }

        public override int CalculateDisturbance()
        {
            return 7;
        }

        public string Feed()
        {
            return $"{Name} receives brains.";
        }
    }
}