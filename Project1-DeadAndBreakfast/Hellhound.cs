namespace DeadAndBreakfast
{
    public class Hellhound : Guest, IFeedable
    {
        public Hellhound(string guestId, string name)
            : base(guestId, name)
        {
        }

        public override string Describe()
        {
            return $"{base.Describe()}, Kind: Hellhound";
        }

        public override string GetAccommodationNeeds()
        {
            return "A fireproof room with a heat-resistant dog bed.";
        }

        public override int CalculateDisturbance()
        {
            return 9;
        }

        public string Feed()
        {
            return $"{Name} receives a bowl of charred meat.";
        }
    }
}