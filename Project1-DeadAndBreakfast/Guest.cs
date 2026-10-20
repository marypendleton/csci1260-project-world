using System;
using System.Collections.Generic;

namespace DeadAndBreakfast
{
    // Represents a guest staying at the supernatural inn.
    public abstract class Guest
    {
        private string _guestId;
        private string _name;
        private List<StayNote> _stayNotes;

        public string GuestId
        {
            get { return _guestId; }
        }

        public string Name
        {
            get { return _name; }
        }

        protected Guest(string guestId, string name)
        {
            if (string.IsNullOrWhiteSpace(guestId))
            {
                throw new ArgumentException("Guest ID cannot be blank.");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Guest name cannot be blank.");
            }

            _guestId = guestId;
            _name = name;
            _stayNotes = new List<StayNote>();
        }

        public virtual string Describe()
        {
            return $"Guest ID: {GuestId}, Name: {Name}";
        }

        public abstract string GetAccommodationNeeds();

        public abstract int CalculateDisturbance();

        public string GetStaySummary()
        {
            return $"{Describe()}\nNeeds: {GetAccommodationNeeds()}";
        }

        public string AddStayNote(string text)
        {
            StayNote note = new StayNote(text);
            _stayNotes.Add(note);

            return $"Stay note added for {Name}.";
        }

        public string GetStayNotes()
        {
            string result = $"Stay notes for {Name}:";

            foreach (StayNote note in _stayNotes)
            {
                result += $"\n{note.Text}";
            }

            return result;
        }
    }
}