using CodeFirstMigrations.DTOs;
using CodeFirstMigrations.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstMigrations.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrescriptionsController : ControllerBase
{
    private IMedicamentsService _medicamentsService;

    public PrescriptionsController(IMedicamentsService medicamentsService)
    {
        _medicamentsService = medicamentsService;
    }

    [HttpPost]
    public async Task<IActionResult> AddPrescription(PrescriptionDto prescriptionDto)
    {
        PrescriptionDto res = await _medicamentsService.AddPrescription(prescriptionDto);
        return Ok(res);
    }
}