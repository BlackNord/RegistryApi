using Registry.Api.Dto.Requests;
using Registry.Api.Dto.Responses;
using Registry.Api.Entities;
using Registry.Api.Repositories;
using Registry.Api.Services.Interfaces;

namespace Registry.Api.Services
{
	public class PatientService : IPatientService
	{
		private readonly IRepository<PatientEntity> repository;

		public PatientService(IRepository<PatientEntity> repository)
		{
			this.repository = repository;
		}

		public async Task<int> CreatePatient(PatientCreateRequest request)
		{
			var entity = new PatientEntity()
			{
				Name = request.Name,
				Surname = request.Surname,
				BirthDate = request.BirthDate,
				ContactNumber = request.ContactNumber
			};

			await repository.Add(entity);

			var result = entity.Id;

			return result;
		}

		public async Task UpdatePatient(PatientUpdateRequest request)
		{
			var patient = await repository.GetById(request.Id);

			if (patient == null)
				throw new Exception("Object Patient is null");

			patient.Name = request.Name;
			patient.Surname = request.Surname;
			patient.BirthDate = request.BirthDate;
			patient.ContactNumber = request.ContactNumber;

			await repository.Update(patient);
		}

		public async Task<PatientResponse> GetPatient(int id)
		{
			var patient = await repository.GetById(id);

			if (patient == null)
				throw new Exception("Object Patient is null");

			var result = GetPatientResponse(patient);
			return result;
		}

		public async Task<IEnumerable<PatientResponse>> GetAllPatients(int? skip = null, int? take = null)
		{
			var patients = await repository.List(skip, take);

			var result = patients.Select(x => GetPatientResponse(x)).ToArray();

			return result;
		}

		public async Task DeletePatient(int id)
		{
			var patient = await repository.GetById(id);

			if (patient == null)
				throw new Exception("Object Patient is null");

			await repository.Delete(patient);
		}

		private PatientResponse GetPatientResponse(PatientEntity source)
		{
			var result = new PatientResponse()
			{
				Id = source.Id,
				Name = source.Name,
				Surname = source.Surname,
				BirthDate = source.BirthDate,
				ContactNumber = source.ContactNumber
			};

			return result;
		}
	}
}
