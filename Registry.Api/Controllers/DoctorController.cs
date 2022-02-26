using Registry.Api.Dto.Requests;
using Registry.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Registry.Api.Controllers
{
	[Route("api/doctors")]
	[ApiController]
	public class DoctorController : ControllerBase
	{
		private readonly IDoctorService doctorService;

		public DoctorController(
			ILogger<DoctorController> logger,
			IDoctorService doctorService)
		{
			this.doctorService = doctorService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll(int? take = null, int? skip = null)
		{
			var result = await doctorService.GetAllDoctors(take, skip);
			return Ok(result);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> Get(int id)
		{
			var result = await doctorService.GetDoctor(id);
			return Ok(result);
		}

		[HttpPut]
		public async Task<IActionResult> Update(DoctorUpdateRequest request)
		{
			await doctorService.UpdateDoctor(request);
			return NoContent();
		}

		[HttpPost]
		public async Task<IActionResult> Create(DoctorCreateRequest request)
		{
			var result = await doctorService.CreateDoctor(request);
			return CreatedAtAction("Get", new { id = result }, result);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete(int id)
		{
			await doctorService.DeleteDoctor(id);
			return NoContent();
		}
	}
}
