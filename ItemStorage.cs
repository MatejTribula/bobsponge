namespace WorldOfZuul;


public class ItemStorage
{
    private string name;
    public List<Item> Items;


    public ItemStorage(string name, List<Item> items)
    {
        this.name = name;
        this.Items = items;
    }

    public void ShowItems()
    {
        int numberOfItems = this.Items.Count();
        if (numberOfItems == 0)
        {
            Console.WriteLine(this.name + " is empty!");
        }
        else
        {
            Console.WriteLine("There are " + numberOfItems + " items in the " + this.name + ": ");
            foreach (Item item in Items)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}