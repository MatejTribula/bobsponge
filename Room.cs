namespace WorldOfZuul
{
    public class Room
    {
        public string ShortDescription { get; private set; }
        public string LongDescription { get; private set; }

        public List<Item> Items;
        public List<Container> Containers;
        public Dictionary<string, Room> Exits { get; private set; } = new();



        public Room(string shortDesc, string longDesc)
        {
            this.ShortDescription = shortDesc;
            this.LongDescription = longDesc;
            this.Items = new List<Item>();
            this.Containers = new List<Container>();

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
