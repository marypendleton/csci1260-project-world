using System;

namespace DeadAndBreakfast
{
    public abstract class UndeadGuest : Guest
    {
        private int _yearsSinceDeath;

        public int YearsSinceDeath
        {
            get { return _yearsSinceDeath;  }
        }

        protected UndeadGuest(string guestId, string name, int yearsSinceDeath) : base(guestId, name)
        {
            if (yearsSinceDeath < 0)
            {
                throw new ArgumentException(
                    "Years since death cannot be negative.");
            }

            _yearsSinceDeath = yearsSinceDeath;
        }

        public override string Describe()
        {
            return $"{base.Describe()}, Years since death: {YearsSinceDeath}";
        }
    }
}