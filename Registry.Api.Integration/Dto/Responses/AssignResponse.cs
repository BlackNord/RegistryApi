namespace Registry.Api.Integration.Dto.Responses
{
	public class AssignResponse
	{
		public bool IsAllowed { get; set; }

		public string? RejectReason { get; set; }
	}
}
