namespace WorldOfZuul;

public class Inventory : ItemStorage
{
    private static Inventory _instance;

    // private constructor to prevent direct instantiation
    private Inventory(string name) : base(name)
    {
    }

    // public static property to get the single instance
    public static Inventory Instance(string name)
    {
        if (_instance == null)
        {
            _instance = new Inventory(name);
        }
        return _instance;
    }


}