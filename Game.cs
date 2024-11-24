namespace WorldOfZuul
{
    public class Game
    {
        private Room? currentRoom;
        private Room? previousRoom;

        public Game()
        {
            CreateRooms();

            Inventory? inventory = new Inventory(new List<string>());
        }

        private void CreateRooms()
        {
            // DONE rewrite everything so player can see where they can go
            // DONE add Kader level
            Room? beach = new("BEACH", "You are on a small sandy beach, the sky is blue, the water is clear, you feel a cool breeze from the sea hitting your face. You can see the SEA in front of you facing NORTH");

            Room? seaLevel = new("SEA", "You have at the sea level, the gate to the underwater world. Many wonderful creatures are surrounding you however few of them dissapear in the EAST. Care to find out why?");

            Room? whirlpool = new("WHIRLPOOL", "You are floating in the water. The nearest land is a bit too far for comfort.\r\nIn front of you is a large powerful whirlpool. You cannot go back anymore, however you can vaguely see a SHIPWRECK to the NORTH, TRASH ISLAND to the EAST, CORAL REEFS to the SOUTH and a NUCLEAR ACCIDENT to the WEST");

            Room? shipwreck = new("SHIPWRECK", "You have entered an underwater shipwreck. The ship looks like it sailed\r\nthe seas hundreds of years ago, however it looks just as grand. There are\r\nwebs and trash caught on its worn body, algae growing all over. You can go back to the WHIRLPOOL by going SOUTH");

            Room? trash_island = new("TRASH ISLAND", "You're in the middle of the sea. There is trash for hundreds and hundreds\r\nof kilometers in every direction, there is no clear water to be seen.\r\nJust seemingly infinite garbage in every direction. You can go back to the WHIRLPOOL by going WEST");

            Room? coral_reefs = new("CORAL REEFS", "You are under the water in someplace tropical and once a paradise.\r\nYou see a huge coral reef before you looking like a smoker's lung, grey, scarred\r\nand tired. You can go back to the WHIRLPOOL by going NORTH");

            Room? nuclear_accident = new("NUCLEAR ACCIDENT", "You have entered the site of what used to be a manmade island\r\nwhich was occupied by one of the world's most powerful nuclear reactors, until it wiped itself\r\noff the face of the earth and left the surrounding ocean an aquatic wasteland filled with debris and radiation. You can go back to the WHIRLPOOL by going EAST");


            beach.SetExit("north", seaLevel);
            seaLevel.SetExit("east", whirlpool);



            whirlpool.SetExits(shipwreck, trash_island, coral_reefs, nuclear_accident);

            shipwreck.SetExit("south", whirlpool);

            trash_island.SetExit("west", whirlpool);

            coral_reefs.SetExit("north", whirlpool);

            nuclear_accident.SetExit("east", whirlpool);

            currentRoom = beach;
        }

        public void Play()
        {
            Parser parser = new();

            PrintWelcome();

            bool continuePlaying = true;
            while (continuePlaying)
            {
                // if player has completed level ad Console.WriteLine("You have already completed this level!");

                Console.WriteLine(currentRoom?.ShortDescription);
                Console.Write("> ");

                string? input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter a command.");
                    continue;
                }

                Command? command = parser.GetCommand(input);

                if (command == null)
                {
                    Console.WriteLine("I don't know that command.");
                    continue;
                }

                switch (command.Name)
                {
                    case "look":
                        Console.WriteLine(currentRoom?.LongDescription);
                        break;

                    case "back":
                        if (previousRoom == null)
                            Console.WriteLine("You can't go back from here!");
                        else
                            currentRoom = previousRoom;
                        break;

                    case "north":
                    case "south":
                    case "east":
                    case "west":
                        Move(command.Name);
                        break;

                    case "quit":
                        continuePlaying = false;
                        break;

                    case "help":
                        PrintHelp();
                        break;

                    case "inventory":
                        // create a method in Invetory.cs for this
                        Console.WriteLine("Inventory so far !!");
                        break;


                    case "take":
                        if (command.SecondWord.Length < 1)
                        {
                            Console.WriteLine("You did not specify what to pick up!");
                            break;
                        }

                        // create adding logic to the Invetory.cs itself and create method for it
                        break;

                    case "drop":
                        // works similiarly like take except you have to remove something from the inventory
                        break;

                    case "open":
                        // not sure how to make this thing work yet but i will get into it
                        break;

                    case "talk":
                        // not sure how to make this thing work yet but i will get into it
                        break;

                    default:
                        Console.WriteLine("I don't know what command.");
                        break;
                }
            }


            Console.WriteLine("Thank you for playing Save the Ocean with Bobsponge!");
        }

        private void Move(string direction)
        {
            // make a condition where player is unable to go "back" if currentRoom == whirlpool
            if (currentRoom?.Exits.ContainsKey(direction) == true)
            {
                previousRoom = currentRoom;
                currentRoom = currentRoom?.Exits[direction];
            }
            else
            {
                Console.WriteLine($"You can't go {direction}!");
            }
        }


        private static void PrintWelcome()
        {
            Console.WriteLine("Welcome to Saving The Ocean with Bobsponge!");
            Console.WriteLine("A game created by the finest video game developers from around the world.");
            Console.WriteLine("I'm Bobsponge! The ocean desperately needs your help, and I'm here to guide you.");

            PrintHelp();
            Console.WriteLine();
        }

        private static void PrintHelp()
        {
            Console.WriteLine();

            //    i do not like these
            /*  
            Console.WriteLine("You look confused.");
            Console.WriteLine("It's okay, youre safe.");
            
            Console.WriteLine("We are on the beach in a cozy little town in Southern Denmark.");
            Console.WriteLine("I have summoned you as a last resort to help save the Earth's aquatic wildlife.");
            Console.WriteLine(); 
            */

            Console.WriteLine("Navigate by typing 'north', 'south', 'east', or 'west'.");
            Console.WriteLine("Type 'look' for more details.");
            Console.WriteLine("Type 'back' to go to the previous room.");
            Console.WriteLine("Type 'help' to print this message again.");
            Console.WriteLine("Type 'quit' to exit the game.");
        }
    }
}
