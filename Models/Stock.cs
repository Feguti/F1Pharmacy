namespace F1Pharmacy.Models;

public class Stock
{
    public int Id { get; set; }
    public string Item { get; set; }
    public string Quantity { get; set; }

    public Stock() {}

    public Stock(int id, string item, string quantity)
    {
        Id = id;
        Item = item;
        Quantity = quantity;
    }
}