namespace Registry.Api.Entities
{
	public class DoctorEntity
	{
		public int Id { get; set; }

		public string? Name { get; set; }

		public string? Surname { get; set; }

		public string? Speciality { get; set; }

		public string? ContactNumber { get; set; }

		public virtual IEnumerable<AppointmentEntity>? Appointments { get; set; }
	}
}
