using CodeFirstMigrations.DTOs;
using CodeFirstMigrations.Models;

namespace CodeFirstMigrations.Services;

public interface IMedicamentsService
{
    public Task<PrescriptionDto> AddPrescription(PrescriptionDto prescriptionDto);
}