namespace F1Pharmacy.Models;

public class Sale
{
    public int Id { get; set; }
    public string Item { get; set; }
    public string Quantity { get; set; }
    public int Value { get; set; }

    public Sale() {}

    public Sale(int id, string item, string quantity, int value)
    {
        Id = id;
        Item = item;
        Quantity = quantity;
        Value = value;
    }
}