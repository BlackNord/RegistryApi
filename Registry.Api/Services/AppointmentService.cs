using Registry.Api.Dto.Requests;
using Registry.Api.Dto.Responses;
using Registry.Api.Entities;
using Registry.Api.Integration.Dto.Requests;
using Registry.Api.Integration.Service.Interfaces;
using Registry.Api.Repositories;
using Registry.Api.Services.Interfaces;

namespace Registry.Api.Services
{
	public class AppointmentService : IAppointmentService
	{
		private readonly IRepository<AppointmentEntity> repository;
		private readonly IRepository<DoctorEntity> doctorRepository;
		private readonly IRepository<PatientEntity> patientRepository;
		private readonly IBillingService billingService;

		public AppointmentService(IRepository<AppointmentEntity> repository,
			IRepository<DoctorEntity> doctorRepository,
			IRepository<PatientEntity> patientRepository,
			IBillingService billingService)
		{
			this.repository = repository;
			this.doctorRepository = doctorRepository;
			this.patientRepository = patientRepository;
			this.billingService = billingService;
		}

		public async Task<int> CreateAppointment(AppointmentCreateRequest request)
		{
			if (!(await doctorRepository.Exists(x => x.Id == request.DoctorId)))
				throw new Exception("Object is null");

			var entity = new AppointmentEntity()
			{
				DoctorId = request.DoctorId,
				AppointmentDate = request.AppointmentDate,
				IsAssigned = request.IsRecorded
			};

			await repository.Add(entity);

			var result = entity.Id;

			return result;
		}

		public async Task UpdateAppointment(AppointmentUpdateRequest request)
		{
			var appointment = await repository.GetById(request.Id);

			if (appointment == null)
				throw new Exception("Object Appointment is null");

			if (!(await patientRepository.Exists(x => x.Id == request.PatientId)))
				throw new Exception("Object Patient is null");

			appointment.PatientId = request.PatientId;
			appointment.AppointmentDate = request.AppointmentDate;
			appointment.IsAssigned = request.IsRecorded;

			await repository.Update(appointment);
		}

		public async Task AssignAppointment(AppointmentAssignRequest request)
		{
			var appointment = await repository.GetById(request.Id);

			var assignRequest = new AssignRequest()
			{
				AssignId = request.Id
			};

			var assignResponse = await billingService.Assign(assignRequest);

			if (!assignResponse.IsAllowed)
				throw new Exception("Operation is not allowed");

			if (appointment == null)
				throw new Exception("Object Appointment is null");

			if (!(await patientRepository.Exists(x => x.Id == request.PatientId)))
				throw new Exception("Object Patient is null");

			appointment.PatientId = request.PatientId;
			appointment.IsAssigned = request.IsRecorded;

			await repository.Update(appointment);
		}

		public async Task<AppointmentResponse> GetAppointment(int id)
		{
			var appointment = await repository.GetById(id);

			if (appointment == null)
				throw new Exception("Object Appointment is null");

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
				throw new Exception("Object Appointment is null");

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
				IsRecorded = source.IsAssigned
			};

			return result;
		}
	}
}
