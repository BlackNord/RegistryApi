using Registry.Api.Dto.Requests;
using Registry.Api.Dto.Responses;
using Registry.Api.Entities;
using Registry.Api.Repositories;
using Registry.Api.Services.Interfaces;

namespace Registry.Api.Services
{
	public class AppointmentService : IAppointmentService
	{
		private readonly IRepository<AppointmentEntity> repository;

		public AppointmentService(IRepository<AppointmentEntity> repository)
		{
			this.repository = repository;
		}

		public async Task<int> CreateAppointment(AppointmentCreateRequest request)
		{
			var entity = new AppointmentEntity()
			{
				DoctorId = request.DoctorId,
				PatientId = request.PatientId,
				AppointmentDate = request.AppointmentDate,
				IsRecorded = request.IsRecorded
			};

			await repository.Add(entity);

			var result = entity.Id;

			return result;
		}

		public async Task UpdateAppointment(AppointmentUpdateRequest request)
		{
			var appointment = await repository.GetById(request.Id);

			if (appointment == null)
				throw new Exception("Object is null");

			appointment.PatientId = request.PatientId;
			appointment.AppointmentDate = request.AppointmentDate;
			appointment.IsRecorded = request.IsRecorded;

			await repository.Update(appointment);
		}

		public async Task AsignAppointment(AppointmentRecordRequest request)
		{
			var appointment = await repository.GetById(request.Id);

			if (appointment == null)
				throw new Exception("Object is null");

			appointment.PatientId = request.PatientId;
			appointment.IsRecorded = request.IsRecorded;

			await repository.Update(appointment);
		}

		public async Task<AppointmentResponse> GetAppointment(int id)
		{
			var appointment = await repository.GetById(id);

			if (appointment == null)
				throw new Exception("Object is null");

			var result = GetAppointmentResponse(appointment);
			return result;
		}

		public async Task<IEnumerable<AppointmentResponse>> GetAllAppointments(int? skip = null, int? take = null)
		{
			var appointments = await repository.List(skip, take);

			var result = appointments.Select(x => GetAppointmentResponse(x)).ToArray();

			return result;
		}

		public async Task DeleteAppointment(int id)
		{
			var appointment = await repository.GetById(id);

			if (appointment == null)
				throw new Exception("Object is null");

			await repository.Delete(appointment);
		}

		private AppointmentResponse GetAppointmentResponse(AppointmentEntity source)
		{
			var result = new AppointmentResponse()
			{
				Id = source.Id,
				DoctorId = source.DoctorId,
				PatientId = source.PatientId,
				AppointmentDate = source.AppointmentDate,
				IsRecorded = source.IsRecorded
			};

			return result;
		}
	}
}
