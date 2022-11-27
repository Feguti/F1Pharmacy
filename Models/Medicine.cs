namespace F1Pharmacy.Models;

public class Medicine
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }

    public Medicine() {}

    public Medicine(int id, string name, string type, string description)
    {
        Id = id;
        Name = name;
        Type = type;
        Description = description;
    }
}