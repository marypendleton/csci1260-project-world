using System;
using System.Collections.Generic;

namespace DeadAndBreakfast
{
    // Sorts stay records by stay number, then guest ID.
    public class StayNumberComparer : IComparer<StayRecord>
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

            int result = first.StayNumber.CompareTo(second.StayNumber);

            if (result != 0)
            {
                return result;
            }

            return string.Compare(
                first.GuestId,
                second.GuestId,
                StringComparison.Ordinal);
        }
    }
}