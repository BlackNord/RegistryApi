using Registry.Api.Dto.Requests;
using Registry.Api.Dto.Responses;

namespace Registry.Api.Services.Interfaces
{
	public interface IPatientService
	{
		Task<int> CreatePatient(PatientCreateRequest request);

		Task UpdatePatient(PatientUpdateRequest request);

		Task<PatientResponse> GetPatient(int id);

		Task<IEnumerable<PatientResponse>> GetAllPatients(int? skip = null, int? take = null);

		Task DeletePatient(int id);
	}
}
