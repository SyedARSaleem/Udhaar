using System;
using System.Collections.Generic;

class User
{
    private string Name;
    private ItemBase item;
    private IStateItem state;
    private List<ItemBase> items = new List<ItemBase>();

    public User(string Name) 
    { 
        this.Name = Name;
    }

    public void book(ItemBase item)
    {
        this.state = item.getavailability();
        if (state.returnavailability() == "Available")
        {
            items.Add(item);
            this.state.book();
        }
        else
        {
            Console.WriteLine(state.checkavailability());
        }

    }
    public void ReturnItem(ItemBase item)
    {
        this.state = new Available(item);
        Console.WriteLine($"{this.Name} Thank You for returning the {item.getname()}");
        item.setavailability(state);
        items.Remove(item);
    }
    public string getname()
    {
        return this.Name;
    }

    public void BookedItems()
    {
        if (items.Count == 0)
        {
            Console.WriteLine($"There is currently no items rented by {this.Name}");
        }
        else 
        {
            Console.WriteLine($"{this.Name} borrowed the following items: ");
            foreach (ItemBase item in items)
            {
                Console.WriteLine(item.getname());
            }
            Console.WriteLine();
        }
    }


}
