namespace F1Pharmacy.Models;

public class Customer
{
    public int Id { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public Customer() {}

    public Customer(int id, string city, string address, string email, string phone)
    {
        Id = id;
        City = city;
        Address = address;
        Email = email;
        Phone = phone;
    }
}