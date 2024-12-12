namespace WorldOfZuul;


public class ItemStorage
{
    public string Name { get; }
    public List<Item> Items = new();


    public ItemStorage(string name)
    {
        this.Name = name;
    }

    public void ShowItems()
    {
        int numberOfItems = this.Items.Count();
        if (numberOfItems == 0)
        {
            Console.WriteLine(this.Name + " is empty!");
        }
        else
        {
            Console.WriteLine("There are " + numberOfItems + " items in the " + this.Name + ": ");
            foreach (Item item in Items)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}