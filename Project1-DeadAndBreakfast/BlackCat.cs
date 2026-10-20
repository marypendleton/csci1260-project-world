namespace DeadAndBreakfast
{
    public class BlackCat : Guest, IFeedable
    {
        public BlackCat(string guestId, string name)
            : base(guestId, name)
        {
        }

        public override string Describe()
        {
            return $"{base.Describe()}, Kind: Black Cat";
        }

        public override string GetAccommodationNeeds()
        {
            return "A cozy room with a scratching post and a sunny window.";
        }

        public override int CalculateDisturbance()
        {
            return 2;
        }

        public string Feed()
        {
            return $"{Name} receives a bowl of cat food.";
        }
    }
}