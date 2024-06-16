using CodeFirstMigrations.Context;
using CodeFirstMigrations.DTOs;
using CodeFirstMigrations.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstMigrations.Services;

public class MedicamentsService : IMedicamentsService
{
    private DatabaseContext _dbContext;

    public MedicamentsService()
    {
        _dbContext = new DatabaseContext();
    }

    public async Task<PrescriptionDto> AddPrescription(PrescriptionDto prescriptionDto)
    {
        Boolean patientExists = await _dbContext.Patients.AnyAsync(x => x.IdPatient == prescriptionDto.PatientDto.IdPatient);
        if (!patientExists)
        {
            Patient patient = new Patient()
            {
                Birthdate = prescriptionDto.PatientDto.Birthdate,
                FirstName = prescriptionDto.PatientDto.FirstName,
                LastName = prescriptionDto.PatientDto.LastName,
                Prescriptions = new List<Prescription>()
            };
            
            await _dbContext.AddAsync(patient);
            await _dbContext.SaveChangesAsync();
        }
        
        foreach (var med in prescriptionDto.Medicaments)
        {
            Boolean medExists = await _dbContext.Medicaments.FindAsync(med) == null;
            if (!medExists)
                throw new Exception("Medicament doesn't exist!");
        }

        int medsCount = prescriptionDto.Medicaments.Count;
        if (medsCount > 10)
            throw new Exception("Too many medicaments on prescription!");

        if (prescriptionDto.DueDate < prescriptionDto.Date)
            throw new Exception("Prescription expired!");

        Prescription prescription = new Prescription()
        {
            Date = prescriptionDto.Date,
            DueDate = prescriptionDto.DueDate,
            IdDoctor = prescriptionDto.Doctor.IdDoctor,
            IdPatient = prescriptionDto.PatientDto.IdPatient,
            IdPrescription = prescriptionDto.IdPrescription
        };

        await _dbContext.AddAsync(prescription);
        await _dbContext.SaveChangesAsync();

        foreach (var med in prescriptionDto.Medicaments)
        {
            PrescriptionMedicament preMed = new PrescriptionMedicament()
            {
                IdMedicament = med.IdMedicament,
                IdPrescription = prescriptionDto.IdPrescription,
                Dose = prescriptionDto.Dose,
                Details = prescriptionDto.Details
            };

            await _dbContext.AddAsync(preMed);
            await _dbContext.SaveChangesAsync();
        }

        return prescriptionDto;
    }
    
}
