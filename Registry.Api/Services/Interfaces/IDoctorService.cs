using Registry.Api.Dto.Requests;
using Registry.Api.Dto.Responses;

namespace Registry.Api.Services.Interfaces
{
	public interface IDoctorService
	{
		Task<int> CreateDoctor(DoctorCreateRequest request);

		Task UpdateDoctor(DoctorUpdateRequest request);

		Task<DoctorResponse> GetDoctor(int id);

		Task<IEnumerable<DoctorResponse>> GetAllDoctors(int? skip = null, int? take = null);

		Task DeleteDoctor(int id);
	}
}
