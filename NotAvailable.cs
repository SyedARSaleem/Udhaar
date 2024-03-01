using System;

class NotAvailable : IStateItem
{
    private ItemBase item;

    public NotAvailable(ItemBase item)
    {
        this.item = item;
    }

    public string returnavailability()
    {
        return "NotAvailable";
    }

    public void book()
    {
        Console.WriteLine($"Sorry! {item.getname()} is already booked, Try booking it later");
    }

    public string checkavailability()
    {
        return $"Sorry! {item.getname()} is already booked";
    }
}
