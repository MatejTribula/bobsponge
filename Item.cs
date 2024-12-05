namespace WorldOfZuul;


public class Item
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    private enum LevelOfOrigin
    {
        Beach,
        Sea,
        Shipwreck,
        TrashIsland,
        CoralReefs,
        NuclearAccident
    };
    public bool IsDroppable { get; }
    public bool IsInInventory { get; set; }


    public Item(string name, string description, bool IsDroppable, bool IsInInventory)
    {
        this.Name = name;
        this.Description = description;
        // this.levelOfOrigin = level;
        this.IsDroppable = IsDroppable;
        this.IsInInventory = IsInInventory;
    }

}