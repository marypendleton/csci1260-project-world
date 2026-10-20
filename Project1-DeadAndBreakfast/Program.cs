using System;
using System.Collections.Generic;
using System.IO;

namespace DeadAndBreakfast
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=== 1. Classes, UML, and Relationships ===");

                string dataPath = Path.Combine(
                    AppContext.BaseDirectory, "data.txt");

                string loadingReport;
                List<Guest> guests = LoadGuests(dataPath, out loadingReport);

                HalloweenHouse house = new HalloweenHouse();

                foreach (Guest guest in guests)
                {
                    Console.WriteLine(house.AddGuest(guest));
                }

                Console.WriteLine($"Guest count: {house.GuestCount}");

                if (guests.Count > 0)
                {
                    Console.WriteLine(
                        guests[0].AddStayNote("Checked in before midnight."));

                    Console.WriteLine(guests[0].GetStayNotes());
                }

                Console.WriteLine(
                    "\n=== 2. Inheritance and Abstraction ===");

                foreach (Guest guest in guests)
                {
                    Console.WriteLine(guest.GetStaySummary());
                    Console.WriteLine(
                        $"Disturbance: {guest.CalculateDisturbance()}");
                }

                Console.WriteLine(
                    "\n=== 3. Polymorphism and Interfaces ===");

                Console.WriteLine(house.GetGuestReport());

                foreach (Guest guest in guests)
                {
                    if (guest is IFeedable feedable)
                    {
                        FeedGuest(feedable);
                    }
                }

                Console.WriteLine(
                    "\n=== 4. Built in Contracts and Collections ===");

                List<StayRecord> records = new List<StayRecord>
        {
            new StayRecord("V01", 2, 5),
            new StayRecord("C01", 3, 2),
            new StayRecord("G01", 1, 3),
            new StayRecord("H01", 1, 9),
            new StayRecord("Z01", 2, 7),
            new StayRecord("G01", 1, 8)
        };

                Console.WriteLine(
                    $"Same key, different score: "
                    + $"{records[2].Equals(records[5])}");

                HashSet<StayRecord> uniqueRecords =
                    new HashSet<StayRecord>(records);

                Console.WriteLine($"Before HashSet: {records.Count}");
                Console.WriteLine($"After HashSet: {uniqueRecords.Count}");

                Console.WriteLine("\nNatural order: guest ID, then stay number");
                records.Sort();

                foreach (StayRecord record in records)
                {
                    Console.WriteLine(record);
                }

                Console.WriteLine("\nOrder by disturbance score");
                records.Sort(new DisturbanceComparer());

                foreach (StayRecord record in records)
                {
                    Console.WriteLine(record);
                }

                Console.WriteLine("\nOrder by stay number, then guest ID");
                records.Sort(new StayNumberComparer());

                foreach (StayRecord record in records)
                {
                    Console.WriteLine(record);
                }

                Console.WriteLine(
                    "\n=== 5. Exceptions and Files ===");

                Console.WriteLine("Starting data loading results:");
                Console.WriteLine(loadingReport);

                try
                {
                    Guest invalidGuest = new BlackCat("", "Salem");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Invalid guest caught: {ex.Message}");
                }

                string logPath = Path.Combine(
                    AppContext.BaseDirectory, "stay-log.txt");

                StayLog log = new StayLog(logPath);

                try
                {
                    using (log)
                    {
                        Console.WriteLine(
                            log.WriteEntry("Guest loading completed."));

                        Console.WriteLine(
                            log.WriteEntry(
                                $"Guests checked in: {house.GuestCount}"));

                        Console.WriteLine(
                            log.WriteEntry("About to test an intentional error."));

                        throw new InvalidOperationException(
                            "Intentional error inside the using block.");
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Caught: {ex.Message}");
                }

                log.Dispose();

                Console.WriteLine(
                    "Dispose called again safely after the using block.");

                Console.WriteLine("\nFinished log file:");
                Console.WriteLine(File.ReadAllText(logPath));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Program could not finish: {ex.Message}");
            }
        }

        private static void FeedGuest(IFeedable guest)
        {
            Console.WriteLine(guest.Feed());
        }

        private static List<Guest> LoadGuests(
    string filePath, out string loadingReport)
        {
            List<Guest> guests = new List<Guest>();
            loadingReport = "";

            string[] lines = File.ReadAllLines(filePath);

            for (int i = 0; i < lines.Length; i++)
            {
                try
                {
                    string[] parts = lines[i].Split('|');

                    if (parts.Length < 3)
                    {
                        throw new FormatException(
                            "A guest needs a type, ID, and name.");
                    }

                    string type = parts[0];
                    string guestId = parts[1];
                    string name = parts[2];

                    Guest guest;

                    switch (type)
                    {
                        case "Ghost":
                        case "Vampire":
                        case "Zombie":
                            if (parts.Length != 4)
                            {
                                throw new FormatException(
                                    "An undead guest needs four values.");
                            }

                            int yearsSinceDeath = int.Parse(parts[3]);

                            if (type == "Ghost")
                            {
                                guest = new Ghost(
                                    guestId, name, yearsSinceDeath);
                            }
                            else if (type == "Vampire")
                            {
                                guest = new Vampire(
                                    guestId, name, yearsSinceDeath);
                            }
                            else
                            {
                                guest = new Zombie(
                                    guestId, name, yearsSinceDeath);
                            }

                            break;

                        case "BlackCat":
                        case "Hellhound":
                            if (parts.Length != 3)
                            {
                                throw new FormatException(
                                    "An animal guest needs three values.");
                            }

                            if (type == "BlackCat")
                            {
                                guest = new BlackCat(guestId, name);
                            }
                            else
                            {
                                guest = new Hellhound(guestId, name);
                            }

                            break;

                        default:
                            throw new FormatException("Unknown guest type.");
                    }

                    guests.Add(guest);
                    loadingReport += $"\nLine {i + 1}: Loaded {guest.Name}.";
                }
                catch (ArgumentException ex)
                {
                    loadingReport += $"\nLine {i + 1}: Skipped. {ex.Message}";
                }
                catch (FormatException ex)
                {
                    loadingReport += $"\nLine {i + 1}: Skipped. {ex.Message}";
                }
                catch (OverflowException ex)
                {
                    loadingReport += $"\nLine {i + 1}: Skipped. {ex.Message}";
                }
            }

            return guests;
        }
    }
}