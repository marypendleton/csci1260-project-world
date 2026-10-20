using System.Collections.Generic;

namespace DeadAndBreakfast
{
    public class DisturbanceComparer : IComparer<StayRecord>
    {
        public int Compare(StayRecord? first, StayRecord? second)
        {
            if (ReferenceEquals(first, second))
            {
                return 0;
            }

            if (first is null)
            {
                return -1;
            }

            if (second is null)
            {
                return 1;
            }

            return first.DisturbanceScore.CompareTo(
                second.DisturbanceScore);
        }
    }
}