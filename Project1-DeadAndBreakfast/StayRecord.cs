using System;

namespace DeadAndBreakfast
{
    public class StayRecord : IEquatable<StayRecord>,
        IComparable<StayRecord>
    {
        private string _guestId;
        private int _stayNumber;
        private int _disturbanceScore;

        public string GuestId
        {
            get { return _guestId; }
        }

        public int StayNumber
        {
            get { return _stayNumber; }
        }

        public int DisturbanceScore
        {
            get { return _disturbanceScore; }
        }

        public StayRecord(string guestId, int stayNumber,
            int disturbanceScore)
        {
            if (string.IsNullOrWhiteSpace(guestId))
            {
                throw new ArgumentException("Guest ID cannot be blank.");
            }

            if (stayNumber < 1)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(stayNumber),
                    "Stay number must be at least 1.");
            }

            if (disturbanceScore < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(disturbanceScore),
                    "Disturbance score cannot be negative.");
            }

            _guestId = guestId;
            _stayNumber = stayNumber;
            _disturbanceScore = disturbanceScore;
        }

        public bool Equals(StayRecord? other)
        {
            if (other is null)
            {
                return false;
            }

            return GuestId == other.GuestId
                && StayNumber == other.StayNumber;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as StayRecord);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GuestId, StayNumber);
        }

        public int CompareTo(StayRecord? other)
        {
            if (other is null)
            {
                return 1;
            }

            int result = string.Compare(
                GuestId, other.GuestId, StringComparison.Ordinal);

            if (result != 0)
            {
                return result;
            }

            return StayNumber.CompareTo(other.StayNumber);
        }

        public override string ToString()
        {
            return $"Guest: {GuestId}, Stay: {StayNumber}, "
                + $"Disturbance: {DisturbanceScore}";
        }
    }
}