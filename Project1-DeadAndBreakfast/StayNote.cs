using System;

namespace DeadAndBreakfast
{
    public class StayNote
    {
        private string _text;

        public string Text
        {
            get { return _text; }
        }

        public StayNote(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            { 
                throw new ArgumentException("Stay note cannot be blank.");
        }
        _text = text;
    }
}
}
