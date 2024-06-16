using CodeFirstMigrations.Models;

namespace CodeFirstMigrations.DTOs;

public class PrescriptionDto
{
    public PatientDto PatientDto { get; set; } = null!;
    public ICollection<Medicament> Medicaments { get; set; } = new List<Medicament>();
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public Doctor Doctor { get; set; } = null!;
    public int Dose { get; set; }
    public string Details { get; set; } = null!;
    public int IdPrescription { get; set; }
}