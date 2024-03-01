using System;

class Available : IStateItem
{
    private ItemBase item;

    public Available(ItemBase item)
    {
        this.item = item;
    }
    public string returnavailability()
    {
        return "Available";
    }
    public void book()
    {
        this.item.setavailability(new NotAvailable(this.item));
        Console.WriteLine($"Thank you for booking {item.getname()} for rent");
    }

    public string checkavailability()
    {
        return $"{item.getname()} is available to book";
    }
}