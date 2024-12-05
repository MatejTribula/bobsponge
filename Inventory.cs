namespace WorldOfZuul;

public class Inventory : ItemStorage
{
    private static Inventory _instance;

    // private constructor to prevent direct instantiation
    private Inventory(string name, List<Item> items) : base(name, items)
    {
    }

    // public static property to get the single instance
    public static Inventory Instance(string name, List<Item> items)
    {
        if (_instance == null)
        {
            _instance = new Inventory(name, items);
        }
        return _instance;
    }


}