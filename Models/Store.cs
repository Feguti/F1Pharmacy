namespace F1Pharmacy.Models;

public class Store
{
    public int Id { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string Manager { get; set; }

    public Store() {}

    public Store(int id, string city, string address, string manager)
    {
        Id = id;
        City = city;
        Address = address;
        Manager = manager;
    }
}