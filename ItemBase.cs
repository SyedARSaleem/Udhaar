using System;

class ItemBase : ItemInterface
{
    protected string ItemName;
    protected string ItemDescription;
    protected int ItemPrice;
    protected IStateItem availability;


    public ItemBase(string ItemName, string ItemDescription, int ItemPrice)
    {
        this.ItemName = ItemName;
        this.ItemDescription = ItemDescription;
        this.ItemPrice = ItemPrice;
        this.availability = new Available(this);
    }

    public string getname()
    {
        return this.ItemName;
    }
    public int getprice()
    {
        return this.ItemPrice;
    }
    public virtual string PrintDetails()
    {
        return $"Product Name: {this.ItemName}\nProduct Description: {this.ItemDescription}\nProduct Price: {this.ItemPrice} pounds per day\n";
    }

    public void setavailability(IStateItem ItemAvailability)
    {
        this.availability = ItemAvailability;
    }


    public string checkavailability()
    {
        return this.availability.checkavailability();
    }

    public IStateItem getavailability()
    {
        return this.availability;
    }

    public void book()
    {
        if (this.availability.returnavailability() == "Available")
        {
            this.availability = new NotAvailable(this);
        }
        else
        {
            Console.WriteLine(availability.checkavailability());
        }

    }

}
