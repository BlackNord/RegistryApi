using Registry.Api.Dto.Requests;
using Registry.Api.Dto.Responses;

namespace Registry.Api.Services.Interfaces
{
	public interface IAppointmentService
	{
		Task<int> CreateAppointment(AppointmentCreateRequest request);

		Task UpdateAppointment(AppointmentUpdateRequest request);

		Task AssignAppointment(AppointmentAssignRequest request);

		Task<AppointmentResponse> GetAppointment(int id);

		Task<IEnumerable<AppointmentResponse>> GetAllAppointments(int? skip = null, int? take = null);

		Task DeleteAppointment(int id);
	}
}
