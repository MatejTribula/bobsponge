namespace WorldOfZuul;

class Inventory
{
    List<Item> Items { get; set; }

    public Inventory(List<Item> initial_items)
    {
        Items = initial_items;
    }


    public void ShowInventory()
    {
        int numberOfItems = Items.Count();
        if (numberOfItems == 0)
        {
            Console.WriteLine("Your inventory is empty!");
        }
        else
        {
            Console.WriteLine("There are " + numberOfItems + " items in your Inventory:");
            foreach (Item item in Items)
            {
                Console.WriteLine(item.Name);
            }
        }
    }

    public void AddItem(string input, string level)
    {
        if (input != null && input.Length > 0)
        {
            Items.Add(new Item(input, level, true, false));
            Console.WriteLine("You have picked up an item called " + input + ", and succesfully added to the Inventory");
        }
    }


    public void DropItem(string input)
    {
        Item removedItem = Items.Find(item => item.Name == input);
        if (removedItem != null)
        {
            if (removedItem.IsDroppable)
            {
                Items.Remove(removedItem);
                Console.WriteLine("You have dropped " + removedItem.Name);
            }
            else
            {
                Console.WriteLine("You cannot drop this item!");
            }
        }
        else
        {
            Console.WriteLine("Your Inventory does not contain this item!");
        }
    }



}