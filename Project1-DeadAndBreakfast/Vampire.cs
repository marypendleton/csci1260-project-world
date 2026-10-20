namespace DeadAndBreakfast
{
    public class Vampire : UndeadGuest, IFeedable
    {
        public Vampire(string guestId, string name, int yearsSinceDeath)
            : base(guestId, name, yearsSinceDeath)
        {
        }

        public override string Describe()
        {
            return $"{base.Describe()}, Kind: Vampire";
        }

        public override string GetAccommodationNeeds()
        {
            return "A room with blackout curtains and no garlic.";
        }

        public override int CalculateDisturbance()
        {
            return 5;
        }

        public string Feed()
        {
            return $"{Name} receives a glass of donated blood.";
        }
    }
}