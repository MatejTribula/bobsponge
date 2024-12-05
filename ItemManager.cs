namespace WorldOfZuul;

public static class ItemManager
{

    public static void AddItem(Item item, List<Item> targetList)
    {
        targetList.Add(item);
    }

    // move  item from source to target list
    public static void MoveItem(string input, List<Item> sourceList, List<Item> targetList)
    {
        Item movedItem = sourceList.Find(item => item.Name.Equals(input, StringComparison.OrdinalIgnoreCase));


        // item was not found
        if (movedItem == null)
        {
            Console.WriteLine("Item not found!");
            return;
        }

        // item is in inventory but is not droppable
        if (movedItem.IsInInventory && !movedItem.IsDroppable)
        {
            Console.WriteLine("You cannot drop this item!");
            return;
        }

        targetList.Add(movedItem);
        sourceList.Remove(movedItem);
        // 
        movedItem.IsInInventory = !movedItem.IsInInventory;
    }



    // move all items from source to target list
    public static void MoveAll(List<Item> sourceList, List<Item> targetList)
    {

        if (sourceList == null || targetList == null)
        {
            Console.WriteLine("Source or target list is null!");
            return;
        }

        if (sourceList.Count == 0)
        {
            Console.WriteLine("Source list is empty!");
            return;
        }

        // create a copy of the list for iteration
        foreach (var item in sourceList.ToList())
        {
            MoveItem(item.Name, sourceList, targetList);
        }
    }

    // clears the whole list of Items
    public static void RemoveAll(List<Item> targetList)
    {
        targetList.Clear();
    }
}