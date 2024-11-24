namespace WorldOfZuul;


public class Item
{
    public string Name { get; private set; }
    private string levelOfOrigin;
    public bool IsDroppable { get; private set; }
    private bool isMythic;

    public Item(string name, string level, bool isDroppable, bool isMythic)
    {
        this.Name = name;
        this.levelOfOrigin = level;
        this.IsDroppable = isDroppable;
        this.isMythic = isMythic;
    }

}