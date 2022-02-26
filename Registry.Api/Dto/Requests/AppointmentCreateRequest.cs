namespace Registry.Api.Dto.Requests
{
	public class AppointmentCreateRequest
	{
		public int DoctorId { get; set; }

		public DateTimeOffset AppointmentDate { get; set; }

		public bool IsRecorded { get; set; }

		public int? PatientId { get; set; }
	}
}
