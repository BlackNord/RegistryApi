namespace Registry.Api.Dto.Responses
{
	public class AppointmentResponse
	{
		public int Id { get; set; }

		public int DoctorId { get; set; }

		public DateTimeOffset AppointmentDate { get; set; }

		public bool IsRecorded { get; set; }

		public int? PatientId { get; set; }
	}
}
