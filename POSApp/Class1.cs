public class Ticket
{


    public string Fooditem;
    public int serverID;
    public double Price;
    public int WaitTime;
    public int TicketID;
    public int[] Tablenum = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    //10 sections in the array for each table in the restaurant
    public double tip;
    public double deposit;
    public bool ticket;
    
    // creating a tip if the deposit is higher than the price of the food item
    void money ()
    {
        if (ticket = 1 && Price < deposit) ;
        //open is 1, closed is 0
        {
            tip = deposit - Price;
        }

    }
    public Food_one(string Burger)
    {
        this.Fooditem = Burger;
        serverID = 1;
        Price = 9.99;
        WaitTime = 15;

    }
    public Food_two(string Fries)
    {
        this.Fooditem = Fries;
        serverID = 2;
        Price = 2.49;
        WaitTime = 7;

    }

    public Food_three(string Shake)
    {
        this.Fooditem = Shake;
        serverID = 3;
        Price = 3.99;
        WaitTime = 5;

    }

    public Food_four(string Chicken_Sand)
    {
        this.Fooditem = Chicken_Sand;
        serverID = 4;
        Price = 8.49;
        WaitTime = 12;

    }

    public Food_five(string Salad)
    {
        this.Fooditem = Salad;
        serverID = 5;
        Price = 11.25;
        WaitTime = 6;

    }

}

