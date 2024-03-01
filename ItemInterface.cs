using System;

interface ItemInterface
{
    public string getname();
    public string PrintDetails();
    public void setavailability(IStateItem ItemAvailability);
    public IStateItem getavailability();
    public string checkavailability();

}
