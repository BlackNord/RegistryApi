namespace Registry.Api.Dto.Requests
{
	public class AppointmentUpdateRequest
	{
		public int Id { get; set; }

		public DateTimeOffset AppointmentDate { get; set; }

		public bool IsRecorded { get; set; }

		public int? PatientId { get; set; }
	}
}
