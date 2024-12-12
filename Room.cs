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
    }
}
