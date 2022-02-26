using Registry.Api.Dto.Requests;
using Registry.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Registry.Api.Controllers
{
	[Route("api/appointments")]
	[ApiController]
	public class AppointmentController : ControllerBase
	{
		private readonly IAppointmentService appointmentService;

		public AppointmentController(
			ILogger<AppointmentController> logger,
			IAppointmentService appointmentService)
		{
			this.appointmentService = appointmentService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll(int? take = null, int? skip = null)
		{
			var result = await appointmentService.GetAllAppointments(take, skip);
			return Ok(result);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> Get(int id)
		{
			var result = await appointmentService.GetAppointment(id);
			return Ok(result);
		}

		[HttpPut]
		public async Task<IActionResult> Update(AppointmentUpdateRequest request)
		{
			await appointmentService.UpdateAppointment(request);
			return NoContent();
		}

		[HttpPut]
		public async Task<IActionResult> Assign(AppointmentAssignRequest request)
		{
			await appointmentService.AssignAppointment(request);
			return NoContent();
		}

		[HttpPost]
		public async Task<IActionResult> Create(AppointmentCreateRequest request)
		{
			var result = await appointmentService.CreateAppointment(request);
			return CreatedAtAction("Get", new { id = result }, result);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete(int id)
		{
			await appointmentService.DeleteAppointment(id);
			return NoContent();
		}
	}
}
