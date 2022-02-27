using Registry.Api.Dto.Requests;
using Registry.Api.Dto.Responses;
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
		[ProducesResponseType(typeof(IEnumerable<DoctorResponse>), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetAll(int? take = null, int? skip = null)
		{
			var result = await doctorService.GetAllDoctors(take, skip);
			return Ok(result);
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(typeof(IEnumerable<DoctorResponse>), StatusCodes.Status200OK)]
		public async Task<IActionResult> Get(int id)
		{
			var result = await doctorService.GetDoctor(id);
			return Ok(result);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> Update(DoctorUpdateRequest request)
		{
			await doctorService.UpdateDoctor(request);
			return NoContent();
		}

		[HttpPost]
		[ProducesResponseType(typeof(IEnumerable<DoctorResponse>), StatusCodes.Status101SwitchingProtocols)]
		public async Task<IActionResult> Create(DoctorCreateRequest request)
		{
			var result = await doctorService.CreateDoctor(request);
			return CreatedAtAction("Get", new { id = result }, result);
		}

		[HttpDelete("{id:int}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> Delete(int id)
		{
			await doctorService.DeleteDoctor(id);
			return NoContent();
		}
	}
}
