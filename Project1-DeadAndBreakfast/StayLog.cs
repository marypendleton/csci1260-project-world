using System;
using System.IO;

namespace DeadAndBreakfast
{

    public class StayLog : IDisposable
    {
        private StreamWriter _writer;
        private bool _disposed;

        public StayLog(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException(
                    "Log file path cannot be blank.");
            }

            _writer = new StreamWriter(filePath);
            _disposed = false;

            _writer.WriteLine("=== DEAD & BREAKFAST LOG ===");
        }

        public string WriteEntry(string message)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(StayLog));
            }

            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException(
                    "Log message cannot be blank.");
            }

            _writer.WriteLine(message);

            return "Log entry recorded.";
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _writer.WriteLine("=== LOG COMPLETE ===");
            _writer.Dispose();
            _disposed = true;
        }
    }
}