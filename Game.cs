namespace WorldOfZuul
{
    public class Game
    {
        private Room? currentRoom;
        private Room? previousRoom;

        private Container? currentContainer;
        private NPC? currentNPC;

        public Game()
        {
            CreateRooms();
        }

        private void CreateRooms()
        {
            // DONE rewrite everything so player can see where they can go
            // DONE add Kader level
            Room? beach = new("BEACH", "You are on a small sandy beach, the sky is blue, the water is clear, you feel a cool breeze from the sea hitting your face. You can see the SEA in front of you facing NORTH");


            ItemManager.AddItem("branch", "just a normal branch", true, false, beach.Items);

            Container chest = new Container("chest");
            beach.SetContainer(chest);
            ItemManager.AddItem("crab", "just a normal crab", true, false, chest.Items);

            NPC patrick = new NPC("patrick the star", "Heeeeey!");
            patrick.AddQA("who are you?", "I AM PATRICK THE STAR!!");
            beach.NPCs.Add("patrick", patrick);


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

            Inventory inventory = Inventory.Instance("Inventory");
            Parser parser = new();

            PrintWelcome();

            bool continuePlaying = true;
            while (continuePlaying)
            {

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

                // might make more sense a a method
                if (command.Name != "loot" && currentContainer != null)
                {

                    Console.WriteLine(command.Name);
                    Console.WriteLine("You have closed the " + currentContainer.Name);

                    currentContainer = null;
                    continue;
                }


                // if current npc exists 
                // if input <= current npc count
                // show the answer to the question with input index
                // else tell player that this is an invalid input
                // afterwards print all the questions again
                if (int.TryParse(input, out int _) && currentNPC != null)
                {
                    currentNPC.ShowQuestions();
                    int intInput = Convert.ToInt32(input);


                    if (intInput <= currentNPC.Questions.Count)
                    {
                        currentNPC.Talk(intInput);
                        continue;
                    }

                    Console.WriteLine("You entered invalid number of question!");

                    continue;

                }

                // if currentNPC != null && input is not numbe stop talking to the npc
                if (!int.TryParse(input, out int _) && currentNPC != null)
                {
                    Console.WriteLine($"You stopped talking to {currentNPC.Name}");
                    currentNPC = null;

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

                    case "help":
                        PrintHelp();
                        break;

                    case "quit":
                        continuePlaying = false;
                        break;

                    case "start":
                        // not sure how to make this thing work yet but i will get into it
                        break;

                    case "inventory":
                        inventory.ShowItems();
                        break;

                    case "take":
                        MoveItem(command.Name, command.SecondWord, currentRoom.Items, inventory.Items);
                        break;

                    case "drop":
                        MoveItem(command.Name, command.SecondWord, inventory.Items, currentRoom.Items);
                        break;


                    // opens selected container inside the room
                    case "open":
                        if (command.SecondWord == null)
                        {
                            Console.WriteLine("You did not specify what to open!");
                            break;
                        }

                        Container openedContainer = currentRoom.Containers.Find(container => container.Name.Equals(command.SecondWord, StringComparison.OrdinalIgnoreCase));

                        if (openedContainer == null)
                        {
                            Console.WriteLine("Container not found!");
                            break;
                        }

                        openedContainer.ShowItems();
                        if (openedContainer.Items.Count > 0)
                        {
                            currentContainer = openedContainer;
                            Console.WriteLine($"Would you like to loot the {openedContainer.Name}? (type loot)");
                        }

                        break;

                    // loots opened container
                    case "loot":
                        if (currentContainer == null)
                        {
                            Console.WriteLine("There is nothing to loot!");
                            break;
                        }

                        ItemManager.MoveAll(currentContainer.Items, inventory.Items);

                        Console.WriteLine("You looted the " + currentContainer.Name + "!");
                        currentContainer = null;
                        break;

                    // starts talking to selected npc if it is in the room
                    case "talk":
                        if (!string.IsNullOrEmpty(command.SecondWord))
                        {

                            if (currentRoom.NPCs.ContainsKey(command.SecondWord))
                            {

                                NPC npc = currentRoom.NPCs[command.SecondWord];

                                currentNPC = npc;
                                currentNPC.PrintGreeting();
                                currentNPC.ShowQuestions();

                                break;
                            }


                            Console.WriteLine($"There is no one named {command.SecondWord} here to talk to.");
                        }
                        else
                        {
                            Console.WriteLine("You need to specify who you want to talk to.");
                        }
                        break;



                    default:
                        Console.WriteLine("I don't know what command.");
                        break;


                }
                Console.WriteLine("");

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
            Console.Clear();
            Console.WriteLine("Welcome to Saving The Ocean with Bobsponge!");
            Console.WriteLine("A game created by the finest video game developers from around the world.");
            Console.WriteLine("I'm Bobsponge! The ocean desperately needs your help, and I'm here to guide you.");

            PrintHelp();
            Console.WriteLine();
        }
        private static void PrintHelp()
        {
            Console.WriteLine();


            Console.WriteLine("Navigate by typing 'north', 'south', 'east', or 'west'.");
            Console.WriteLine("Type 'look' for more details.");
            Console.WriteLine("Type 'back' to go to the previous room.");
            Console.WriteLine("Type 'help' to print this message again.");
            Console.WriteLine("Type 'inventory' to print all the items in your inventory.");
            Console.WriteLine("Type 'take' + name of the item you want to add to your inventory.");
            Console.WriteLine("Type 'drop' + name of the item you want to drop from your inventory.");

            // these are not finished yet
            Console.WriteLine("Type 'open' + name of the container you want to open.");
            Console.WriteLine("Type 'talk' + first name of the character you want to talk to");
            Console.WriteLine("Type 'start' to start a minigame");

            Console.WriteLine("Type 'quit' to exit the game.");
        }




        private void MoveItem(string firstWord, string secondWord, List<Item> sourceList, List<Item> targerList)
        {
            Item movedItem = ItemManager.FindItem(secondWord, sourceList);

            ItemManager.MoveItem(secondWord, sourceList, targerList);

            if (movedItem == null)
            {
                return;
            }

            if (firstWord == "take")
            {
                Console.WriteLine("You took " + secondWord + "!");
            }
            else if (firstWord == "drop")
            {
                Console.WriteLine("You dropped " + secondWord + "!");
            }

        }
    }

}
