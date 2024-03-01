using System;
using System.Collections.Generic;


class Store
{
    private static readonly object lockObject = new object();
    private static Store storeInstance = null;

    private List<ItemBase> ItemList = new List<ItemBase>();

    private Store() { }

    public static Store Instance()
    {
        if (storeInstance == null)
        {
            lock (lockObject)
            {
                if (storeInstance == null)
                {
                    storeInstance = new Store();
                }
            }
        }
        return storeInstance;
    }

    public void AddItem(ItemBase item)
    {
        if (!ItemList.Contains(item))
            ItemList.Add(item);
    }

    public IEnumerable<ItemBase> GetItemList()
    {
        return ItemList;
    }
    public void PrintItems()
    {
        foreach (ItemBase item in ItemList)
        {
            Console.WriteLine(item.PrintDetails());
            Console.WriteLine("-------------------------------------\n");
        }
        return;
    }

    public ItemBase GetItem(string name)
    {
        foreach (ItemBase item in ItemList)
        {
            if (item.getname() == name)
            {
                return item;
            }    
        }
        return null;
    }

}
