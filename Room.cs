namespace WorldOfZuul
{
    public class Room
    {
        public string ShortDescription { get; private set; }
        public string LongDescription { get; private set; }

        public List<Item> Items = new();
        public List<Container> Containers = new();
        public Dictionary<string, NPC> NPCs = new();
        public Dictionary<string, Room> Exits { get; private set; } = new();

        public Minigame Minigame { get; set; }



        public Room(string shortDesc, string longDesc)
        {
            this.ShortDescription = shortDesc;
            this.LongDescription = longDesc;
        }

        public void SetExits(Room? north, Room? east, Room? south, Room? west)
        {
            SetExit("north", north);
            SetExit("east", east);
            SetExit("south", south);
            SetExit("west", west);
        }

        public void SetExit(string direction, Room? neighbor)
        {
            if (neighbor != null)
                Exits[direction] = neighbor;
        }

        public void SetContainer(Container container)
        {
            Containers.Add(container);
        }
        public void SetNPC(string name, NPC npc)
        {
            NPCs.Add(name, npc);
        }

        public void PrintEverything()
        {
            Console.WriteLine(LongDescription);
            Console.WriteLine();

            PrintExits();
            PrintItems();
            PrintContainers();
            PrintNPCs();
            PrintMinigame();

        }

        private void PrintExits()
        {
            foreach (var exit in Exits)
            {
                string direction = exit.Key;
                Room connectedRoom = exit.Value;


                Console.WriteLine($"By going: {direction}, You will enter: {connectedRoom.ShortDescription}");
            }
            Console.WriteLine();
        }

        private void PrintItems()
        {
            if (Items.Count == 0) return;

            if (Items.Count == 1)
            {
                Console.WriteLine($"There is an item: {Items[0].Name}");
            }
            else
            {
                Console.WriteLine("There are some items:");
                Console.WriteLine(string.Join(", ", Items.Select(item => item.Name)));
            }
        }

        private void PrintContainers()
        {
            if (Containers.Count == 0) return;

            if (Containers.Count == 1)
            {
                Console.WriteLine($"There is a container that looks like: {Containers[0].Name}");
            }
            else
            {
                Console.WriteLine("There are multiple containers:");
                Console.WriteLine(string.Join(", ", Containers.Select(container => container.Name)));
            }

        }

        private void PrintNPCs()
        {
            if (NPCs.Count == 0) return;

            if (NPCs.Count == 1)
            {
                Console.WriteLine($"There is a being called: {NPCs.ElementAt(0).Value.Name}");
            }
            else
            {
                Console.WriteLine("There are multiple characters:");
                Console.WriteLine(string.Join(", ", NPCs.Values.Select(npc => npc.Name)));
            }
        }

        private void PrintMinigame()
        {
            if (Minigame == null) return;
            Console.WriteLine("There is a minigame located in this room");
            Console.WriteLine();
        }
    }
}
