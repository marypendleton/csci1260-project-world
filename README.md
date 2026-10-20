# csci1260-project-world
Halloween Bed and Breakfast - Project 1

Mary Pendleton
CSCI 1260 002
C#

Dead & Breakfast is my bed and breakfast for the supernatural. It manages stays for ghosts, vampires, zombies, black cats, and hellhounds.
How to Run - Open the project in Visual Studio and select Debug -> Start Without Debugging. The program reads guests from data.txt and prints five sections with the required concepts. It catches the intentionally invalid line. A stay-log.txt is created in its output directory.

1. My aggregation is between HalloweenHouse and Guest. Program creates the guests and they are passed to AddGuest(). Removing HalloweenGouse does not destroy guests still referenced somewhere else, like in the Program's guest list. Moving guest creation into HalloweenHouse would change this relationship to composition. My composition is between Guest and StayNote. The guest creates its own notes inside AddStayNote() and keeps them in a private collection. When the guest and its notes are no longer reachable, they are eligible for garbage collection. Changing AddStayNote() to accept externally created notes instead of creating it internally would make it aggregation.

2. IFeedable defines the Feed() behavior and is implemented by Vampire, Zombie, BlackCat, and Hellhound. These classes come from different branches, as Vampire and Zombie inherit from UndeadGuest, while BlackCat and Hellgound inherit directly from guest. Feeding does not belong on guest or UndeadGuest because the Ghost does not eat. The interface lets the program feed any guest that needs this behavior without requiring that every guest implement it.

3. I could add a Werewolf that inherits directly from Guest and implements IFeedable. I would create Werewolf.cs with its constructor, describing override, accomodation needs, disturbance calculation, and feeding method. I would edit Program.cs to recognize the Werewolf type in LoadGuests(), add a werewolf entry to data.txt and update the UML diagram and the README to reflect the addition. HalloweenHouse.cs would not change because it already stores Guest objects and calls their overridden methods. The reporting and feeding loops would work with Werewolf.

Unfinished Work - Recorded Code Review 
