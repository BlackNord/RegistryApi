namespace Registry.Api.Entities
{
	public class AppointmentEntity
	{
		public int Id { get; set; }

		public int DoctorId { get; set; }

		public int PatientId { get; set; }
	}
}
