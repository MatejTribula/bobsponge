namespace WorldOfZuul
{
    public class Game
    {
        private Room? currentRoom;
        private Room? previousRoom;

        private Container? currentContainer;
        private NPC? currentNPC;

        private List<Minigame> minigames = new();
        private bool isVictorious = false;


        public Game()
        {
            CreateRooms();
        }

        private void CreateRooms()
        {
            Room? beach = new("BEACH", "You are on a small sandy beach, the sky is blue, the water is clear, you feel a cool breeze from the sea hitting your face. You can see the SEA in front of you facing NORTH");


            ItemManager.AddItem("branch", "just a normal branch", true, false, beach.Items);

            Container chest = new Container("chest");
            beach.SetContainer(chest);
            ItemManager.AddItem("crab", "just a normal crab", true, false, chest.Items);

            NPC patrick = new NPC("patrick", "Heeeeey!");
            patrick.AddQA("who are you?", "I AM PATRICK THE STAR!!");
            beach.SetNPC("patrick", patrick);

            // kader's level
            //center


            Room? seaLevel = new("SEA LEVEL, CENTER", "You are at the sea level. You stand at the edge of the sparkling ocean. Ahead of you lies an adventure that could save the seas. Are you ready?");

            //coastline location

            Room? coastline = new("SEA LEVEL, COASTLINE", "Good choice! The beach is covered in plastic and other waste. It's time to clean up and protect marine life.");

            Minigame PickTrash = new PickTrash();
            coastline.minigame = PickTrash;
            minigames.Add(PickTrash);

            //turtle lagoon

            Room? turtleLagoon = new("SEA LEVEL, TURTLE LAGOON", "Welcome! Turtles nest here. They need your help to stay safe and avoid dangerous plastic waste.");

            Minigame GuideTurtles = new GuideTurtle();
            turtleLagoon.minigame = GuideTurtles;
            minigames.Add(GuideTurtles);

            Room? seagullHaven = new("SEA LEVEL, SEAGULL HAVEN", "Seagulls are spreading waste around. You must stop them from making things worse.");

            Minigame ScareSeagull = new ScareSeagulls();
            seagullHaven.minigame = ScareSeagull;
            minigames.Add(ScareSeagull);

            Room? coastline = new("COASTLINE", "");

            Minigame minigameCoastline = new Coastline();
            coastline.Minigame = minigameCoastline;
            minigames.Add(minigameCoastline);

            Room? whirlpool = new("WHIRLPOOL", "You are floating in the water. The nearest land is a bit too far for comfort.\r\nIn front of you is a large powerful whirlpool. You cannot go back anymore, however you can vaguely see a SHIPWRECK to the NORTH, TRASH ISLAND to the EAST, CORAL REEFS to the SOUTH and a NUCLEAR ACCIDENT to the WEST");

            Room? shipwreck = new("SHIPWRECK", "You have entered an underwater shipwreck. The ship looks like it sailed\r\nthe seas hundreds of years ago, however it looks just as grand. There are\r\nwebs and trash caught on its worn body, algae growing all over. You can go back to the WHIRLPOOL by going SOUTH");


            // matej's level

            // CENTER
            Room? trashIsland = new("TRASH ISLAND, CENTER", "Somehow you managed to enter the center of the trash island. There is trash for hundreds and hundreds\r\nof kilometers in every direction, there is no clear water to be seen. Just seemingly infinite garbage in every direction.");

            ItemManager.AddItem("robotic-arm", "a robotic arm of the robot located somewhere in TRASH ISLAND", false, false, trashIsland.Items);

            // JUNK CREATER
            Room? junkCreater = new("TRASH ISLAND, CREATER OF JUNK", "You’re in a place piled high with trash: old fishing nets, rusted parts, and broken electronics everywhere");

            Minigame minigameTrashIsland = new MinigameTrashIsland();
            junkCreater.Minigame = minigameTrashIsland;
            minigames.Add(minigameTrashIsland);


            // SEA OF SLUDGE
            Room? seaSludge = new("TRASH ISLAND, SEA OF SLUDGE", "The Sea of Sludge is a murky stretch of water, thick with oil, plastic, and chemicals. Trash floats everywhere, and the air smells rotten. The waves barely move, carrying more waste with each pass. It’s a grim reminder of how pollution is poisoning the sea");

            Container sludgeBarrel = new Container("barrel");
            ItemManager.AddItem("fishing-net", "Fishing net, that might be of use later!", false, false, sludgeBarrel.Items);
            ItemManager.AddItem("WD40", "Great rust remover!", true, false, sludgeBarrel.Items);
            junkCreater.SetContainer(sludgeBarrel);

            NPC seal = new("seal", "Hello there...");

            seal.AddQA("Who are you?", "I am just an ordinary seal...");
            seal.AddQA("Why are you here?", "Well I got lost...");
            seal.AddQA("Why do you look so tired?", "I have unfortunately consumed something that is causing me a great pain...");
            seal.AddQA("How can I help you?", "I do not think that you will be able to help me anymore. It is too late... The only wish I have now is to prevent this from happening to any other creature ever again!");

            seaSludge.SetNPC("seal", seal);

            // GLASS CANYON
            Room? glassCanyon = new("TRASH ISLAND, GLASS CANYON", "Amid all the trash, a canyon made of glass bottles, jars, mobile screens and other similiar objects was created. At first glance it looks marvelous, reflecting light in a way that makes it appear shiny and almost magical. However, its existence raises some unsettling questions");

            NPC robot = new("robot", "Beep scanning beep");
            robot.AddQA("Who are you?", "Me? I am just a robot that was designed to fix a problem made by humans. Who could have known I was doing the opposite?");
            robot.AddQA("Why are you here?", "I was meant to clear ocean of all the junk created by people on the mainland, trash they dumped into rivers and seas instead of recycling, which eventually reached the oceans. The fishing industry has also contributed significantly by leaving behind fishing nets, hooks, and other hazardous items, causing the death of marine life.");

            robot.AddQA("What is this place?", "This... This is the result of people's ignorance, an island of trash. It's a so-called 'temporary solution', where people on the mainland dispose of waste they no longer need, sacrificing the marine ecosystem in return. But what they fail to realize is that this trash is poisoning the water, killing marine life, and ultimately, it will come back to haunt humanity as the balance of nature collapses.");

            robot.AddQA("Why is here so much glass here?", "This is the last thing I managed to do. I collected all the glass inside the trash island and left it here. Glass does not damage the sea, but it can still injure the marine life. Despite all the negatives it is unbelievably beautiful isn't it?");

            robot.AddQA("Why are you missing an arm?", "I was badly damaged by a fishing hook and lost it somewhere in the TRASH ISLAND. You can take it if you find it, it might be useful to you later.");

            robot.AddQA("How can I help?", "If I could, I would have done it myself. Unfortunately, I am unable to move because I was damaged while dealing with the trash. You must stop new trash from reaching this island. The junk already here is entangled with marine life, and removing it would only harm them further. Head to the CRATER OF JUNK that is to the NORTH of the CENTER of the TRASH ISLAND. There you will be able to get rid of all the incoming trash and sort it");

            robot.AddQA("Have you met anyone here?", "No I haven't, however I have seen some creature entering SEA OF SLUDGE that is to the EAST of the CENTER of the TRASH ISLAND.");

            glassCanyon.SetNPC("robot", robot);



            Room? coralReefs = new("CORAL REEFS", "You are under the water in someplace tropical and once a paradise.\r\nYou see a huge coral reef before you looking like a smoker's lung, grey, scarred\r\nand tired. You can go back to the WHIRLPOOL by going NORTH");

            Minigame minigameCoralReefs = new CoralReef();
            coralReefs.Minigame = minigameCoralReefs;
            minigames.Add(minigameCoralReefs);

            Room? nuclear_accident = new("NUCLEAR ACCIDENT", "You have entered the site of what used to be a manmade island\r\nwhich was occupied by one of the world's most powerful nuclear reactors, until it wiped itself\r\noff the face of the earth and left the surrounding ocean an aquatic wasteland filled with debris and radiation. You can go back to the WHIRLPOOL by going EAST");


            beach.SetExit("north", seaLevel);
<<<<<<< HEAD
            seaLevel.SetExit("east", whirlpool);
            seaLevel.SetExit("west", coastline);
            coastline.SetExit("east", seaLevel);
=======
            // kader's exit for levels
            seaLevel.SetExits(coastline, whirlpool, beach, seagullHaven);
            seagullHaven.SetExit("north",turtleLagoon);
            seagullHaven.SetExit("east",seaLevel);
            coastline.SetExit("south",seaLevel);
    
            
>>>>>>> kader



            whirlpool.SetExits(shipwreck, trashIsland, coralReefs, nuclear_accident);

            shipwreck.SetExit("south", whirlpool);


            // matej's level
            trashIsland.SetExits(junkCreater, seaSludge, glassCanyon, whirlpool);
            junkCreater.SetExit("south", trashIsland);
            seaSludge.SetExit("west", trashIsland);
            glassCanyon.SetExit("north", trashIsland);


<<<<<<< HEAD

            coralReefs.SetExit("north", whirlpool);
=======
            coral_reefs.SetExit("north", whirlpool);
>>>>>>> kader

            nuclear_accident.SetExit("east", whirlpool);

            currentRoom = beach;
        }

        public void Play()
        {

            Inventory inventory = Inventory.Instance("Inventory");
            Parser parser = new();

            PrintWelcome();

            bool continuePlaying = true;
            isVictorious = false;

            while (continuePlaying)
            {
                // checks if game is completed
                if (CalcProgress() == 100)
                {
                    // continuePlaying = false;
                    // isVictorious = true;
                    // continue;

                    isVictorious = true;
                    Console.WriteLine("You have completed all activities already! You can still look around!");

                }

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

                // if current npc exists 
                // if input <= current npc count
                // show the answer to the question with input index
                // else tell player that this is an invalid input
                // afterwards print all the questions again
                if (int.TryParse(input, out int _) && currentNPC != null)
                {
                    currentNPC.ShowQuestions();
                    Console.WriteLine("Stop talking? (type bye)");
                    Console.WriteLine();
                    int intInput = Convert.ToInt32(input);


                    if (intInput <= currentNPC.Questions.Count)
                    {
                        currentNPC.Talk(intInput);
                        continue;
                    }

                    Console.WriteLine("You entered invalid number of question!");

                    continue;

                }

                // might make more sense a a method
                // checks if there is any other input while there is an open chest/ player is talking to an NPC
                if ((command.Name != "loot" && command.Name != "close" && currentContainer != null) || (command.Name != "bye" && currentNPC != null)
                 )
                {
                    Console.WriteLine(command.Name);
                    Console.WriteLine("You cannot do that now");

                    continue;
                }

                switch (command.Name)
                {
                    case "look":
                        currentRoom.PrintEverything();
                        break;

                    case "back":
                        if (previousRoom == null || (previousRoom.ShortDescription == "SEA" && currentRoom.ShortDescription == "WHIRLPOOL"))
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
                            Console.WriteLine($"Would you like to close chest? (type close)");
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

                    case "close":
                        if (currentContainer == null)
                        {
                            Console.WriteLine("There is nothing to close!");
                            break;
                        }
                        Console.WriteLine("You have closed the " + currentContainer.Name);

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
                                Console.WriteLine("Stop talking? (type bye)");

                                break;
                            }


                            Console.WriteLine($"There is no one named {command.SecondWord} here to talk to.");
                        }
                        else
                        {
                            Console.WriteLine("You need to specify who you want to talk to.");
                        }
                        break;

                    case "bye":
                        if (currentNPC == null)
                        {
                            Console.WriteLine("You are not talking to anyone!");
                            break;
                        }

                        Console.WriteLine($"You stopped talking to {currentNPC.Name}");
                        currentNPC = null;
                        break;

                    case "start":
                        if (currentRoom.Minigame == null)
                        {
                            Console.WriteLine("You cannot start any activity here!");
                            break;
                        }
                        if (currentRoom.Minigame.IsComplete == true)
                        {
                            Console.WriteLine("You have already successfully completed this activity!");
                            break;
                        }
                        currentRoom.Minigame.Play();
                        break;

                    case "goal":
                        PrintGoal();
                        break;

                    case "progress":
                        PrintProgress();
                        break;


                    default:
                        Console.WriteLine("I don't know what command.");
                        break;


                }
                Console.WriteLine("");

            }

            PrintEnding();
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
            Console.WriteLine("Type 'goal' to see the goal.");
            Console.WriteLine("Type 'progress' to see your current progress.");
            Console.WriteLine("Type 'help' to print this message again.");
            Console.WriteLine("Type 'inventory' to print all the items in your inventory.");
            Console.WriteLine("Type 'take' + name of the item you want to add to your inventory.");
            Console.WriteLine("Type 'drop' + name of the item you want to drop from your inventory.");
            Console.WriteLine("Type 'open' + name of the container you want to open.");
            Console.WriteLine("Type 'talk' + first name of the character you want to talk to");

            // this one is not done
            Console.WriteLine("Type 'start' to start a minigame");
            Console.WriteLine("Type 'quit' to exit the game.");
        }

        private void PrintGoal()
        {
            Console.WriteLine("The goal is to explore the ocean and learn more about it and its creatures. To win you need to complete all the minigames available");
        }

        private void PrintEnding()
        {
            if (isVictorious)
            {
                Console.WriteLine("You have made an ocean a safe place!");
                Console.WriteLine("Well... Actually not, this is just a game, nothing else");
                Console.WriteLine("You need to start taking action in real life!");
                Console.WriteLine();
            }
        }

        private void PrintProgress()
        {
            Console.WriteLine($"Your current progress is {CalcProgress()}%");
        }

        private double CalcProgress()
        {
            var minigameCount = minigames.Count;
            var completed = 0;


            foreach (var minigame in minigames)
            {
                if (minigame.IsComplete)
                {
                    completed++;
                }
            }

            var completitionPercentage = (double)(100 * completed) / minigameCount;

            return completitionPercentage;
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
