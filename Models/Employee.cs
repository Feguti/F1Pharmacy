namespace F1Pharmacy.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public Employee() {}

    public Employee(int id, string name, string role, string address, string email, string phone)
    {
        Id = id;
        Name = name;
        Role = role;
        Address = address;
        Email = email;
        Phone = phone;
    }
}