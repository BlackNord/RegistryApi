using Registry.Api.Dto.Requests;
using Registry.Api.Dto.Responses;
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
		[ProducesResponseType(typeof(IEnumerable<AppointmentResponse>), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetAll(int? take = null, int? skip = null)
		{
			var result = await appointmentService.GetAllAppointments(take, skip);
			return Ok(result);
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(typeof(IEnumerable<AppointmentResponse>), StatusCodes.Status200OK)]
		public async Task<IActionResult> Get(int id)
		{
			var result = await appointmentService.GetAppointment(id);
			return Ok(result);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> Update(AppointmentUpdateRequest request)
		{
			await appointmentService.UpdateAppointment(request);
			return NoContent();
		}

		[HttpPost("assign")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> Assign(AppointmentAssignRequest request)
		{
			await appointmentService.AssignAppointment(request);
			return NoContent();
		}

		[HttpPost]
		[ProducesResponseType(typeof(IEnumerable<AppointmentResponse>), StatusCodes.Status101SwitchingProtocols)]
		public async Task<IActionResult> Create(AppointmentCreateRequest request)
		{
			var result = await appointmentService.CreateAppointment(request);
			return CreatedAtAction("Get", new { id = result }, result);
		}

		[HttpDelete("{id:int}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> Delete(int id)
		{
			await appointmentService.DeleteAppointment(id);
			return NoContent();
		}
	}
}
