using Registry.Api.Integration.Dto.Requests;
using Registry.Api.Integration.Dto.Responses;

namespace Registry.Api.Integration.Service.Interfaces
{
	public interface IBillingService
	{
		Task<AssignResponse> Assign(AssignRequest request);
	}
}
