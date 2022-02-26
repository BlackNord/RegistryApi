namespace Registry.Api.Dto.Requests
{
	public class AppointmentAsignRequest
	{
		public int Id { get; set; }

		public bool IsRecorded { get; set; }

		public int? PatientId { get; set; }
	}
}
