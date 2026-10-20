using System;
using System.Collections.Generic;

namespace DeadAndBreakfast
{
    public class HalloweenHouse
    {
        private List<Guest> _guests;

        public int GuestCount
        {
            get { return _guests.Count; }
        }

        public HalloweenHouse()
        {
            _guests = new List<Guest>();
        }

        public string AddGuest(Guest guest)
        {
            if (guest == null)
            {
                throw new ArgumentNullException(
                    nameof(guest), "Guest cannot be null.");
            }

            _guests.Add(guest);

            return $"{guest.Name} was added to Dead & Breakfast.";
        }

        public string GetGuestReport()
        {
            string report = "=== DEAD & BREAKFAST GUESTS ===";

            foreach (Guest guest in _guests)
            {
                report += $"\n{guest.Describe()}";
            }

            return report;
        }
    }
}