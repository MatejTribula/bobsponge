namespace WorldOfZuul;

class Inventory
{
    List<string> Items { get; set; };

    public Inventory(List<string> initial_items)
    {
        Items = initial_items;
    }
}