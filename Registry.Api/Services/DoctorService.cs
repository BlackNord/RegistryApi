using Registry.Api.Dto.Requests;
using Registry.Api.Dto.Responses;
using Registry.Api.Entities;
using Registry.Api.Repositories;
using Registry.Api.Services.Interfaces;

namespace Registry.Api.Services
{
	public class DoctorService : IDoctorService
	{
		private readonly IRepository<DoctorEntity> repository;

		public DoctorService(IRepository<DoctorEntity> repository)
		{
			this.repository = repository;
		}

		public async Task<int> CreateDoctor(DoctorCreateRequest request)
		{
			var entity = new DoctorEntity()
			{
				Name = request.Name,
				Surname = request.Surname,
				Speciality = request.Speciality,
				ContactNumber = request.ContactNumber
			};

			await repository.Add(entity);

			var result = entity.Id;

			return result;
		}

		public async Task UpdateDoctor(DoctorUpdateRequest request)
		{
			var doctor = await repository.GetById(request.Id);

			if (doctor == null)
				throw new Exception("Object is null");

			doctor.Name = request.Name;
			doctor.Surname = request.Surname;
			doctor.Speciality = request.Speciality;
			doctor.ContactNumber = request.ContactNumber;

			await repository.Update(doctor);
		}

		public async Task<DoctorResponse> GetDoctor(int id)
		{
			var doctor = await repository.GetById(id);

			if (doctor == null)
				throw new Exception("Object is null");

			var result = GetDoctorResponse(doctor);
			return result;
		}

		public async Task<IEnumerable<DoctorResponse>> GetAllDoctors(int? skip = null, int? take = null)
		{
			var doctors = await repository.List(skip, take);

			var result = doctors.Select(x => GetDoctorResponse(x)).ToArray();

			return result;
		}

		public async Task DeleteDoctor(int id)
		{
			var doctor = await repository.GetById(id);

			if (doctor == null)
				throw new Exception("Object is null");

			await repository.Delete(doctor);
		}

		private DoctorResponse GetDoctorResponse(DoctorEntity source)
		{
			var result = new DoctorResponse()
			{
				Id = source.Id,
				Name = source.Name,
				Surname = source.Surname,
				Speciality = source.Speciality,
				ContactNumber = source.ContactNumber
			};

			return result;
		}
	}
}
