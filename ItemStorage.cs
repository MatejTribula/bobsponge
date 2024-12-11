namespace WorldOfZuul;


public class ItemStorage
{
    public string Name { get; }
    public List<Item> Items;


    public ItemStorage(string name, List<Item> items)
    {
        this.Name = name;
        this.Items = items;
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