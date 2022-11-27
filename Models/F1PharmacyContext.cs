using Microsoft.EntityFrameworkCore;

namespace F1Pharmacy.Models;

public class F1PharmacyContext : DbContext
{
    public DbSet<Store> Stores { get; set; }
    public DbSet<Medicine> Medicines { get; set; }
    
    public F1PharmacyContext(DbContextOptions<F1PharmacyContext> options) : base(options)
    {
        
    }
}