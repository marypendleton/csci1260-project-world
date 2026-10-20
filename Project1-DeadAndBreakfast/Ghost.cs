namespace DeadAndBreakfast
{
    public class Ghost : UndeadGuest
    {
        public Ghost(string guestId, string name, int yearsSinceDeath)
            : base(guestId, name, yearsSinceDeath)
        {
        }

        public override string Describe()
        {
            return $"{base.Describe()}, Kind: Ghost";
        }

        public override string GetAccommodationNeeds()
        {
            return "A quiet room with space to float through the walls.";
        }

        public override int CalculateDisturbance()
        {
            return 3;
        }
    }
}