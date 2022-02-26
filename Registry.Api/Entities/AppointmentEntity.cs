namespace Registry.Api.Entities
{
	public class AppointmentEntity
	{
		public int Id { get; set; }

		public int DoctorId { get; set; }

		public virtual DoctorEntity? Doctor { get; set; }

		public DateTimeOffset AppointmentDate { get; set; }

		public bool IsRecorded { get; set; }

		public int? PatientId { get; set; }

		public virtual PatientEntity? Patient { get; set; }
	}
}
