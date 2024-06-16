using CodeFirstMigrations.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstMigrations.Context;

public class DatabaseContext : DbContext
{

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    
    public DbSet<AppUser> Users { get; set; }
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>()
        {
            new() {IdMedicament = -1, Name = "lek", Description = "hahaha", Type = "asdadas"},
            new() {IdMedicament = -2, Name = "lezcxk", Description = "hahczxaha", Type = "asdaasdasddas"},
            new() {IdMedicament = -3, Name = "lezdasxck", Description = "hahdasdzcxaha", Type = "asdaasdasdasddas"}
        });
    }
}