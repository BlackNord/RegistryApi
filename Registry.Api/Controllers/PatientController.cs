using Registry.Api.Dto.Requests;
using Registry.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Registry.Api.Controllers
{
	[Route("api/patients")]
	[ApiController]
	public class PatientController : ControllerBase
	{
		private readonly IPatientService patientService;

		public PatientController(
			ILogger<PatientController> logger,
			IPatientService patientService)
		{
			this.patientService = patientService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll(int? take = null, int? skip = null)
		{
			var result = await patientService.GetAllPatients(take, skip);
			return Ok(result);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> Get(int id)
		{
			var result = await patientService.GetPatient(id);
			return Ok(result);
		}

		[HttpPut]
		public async Task<IActionResult> Update(PatientUpdateRequest request)
		{
			await patientService.UpdatePatient(request);
			return NoContent();
		}

		[HttpPost]
		public async Task<IActionResult> Create(PatientCreateRequest request)
		{
			var result = await patientService.CreatePatient(request);
			return CreatedAtAction("Get", new { id = result }, result);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete(int id)
		{
			await patientService.DeletePatient(id);
			return NoContent();
		}
	}
}
