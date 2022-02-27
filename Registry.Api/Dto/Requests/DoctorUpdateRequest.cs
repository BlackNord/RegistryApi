namespace Registry.Api.Dto.Requests
{
	public class DoctorUpdateRequest
	{
		public int Id { get; set; }

		public string? Name { get; set; }

		public string? Surname { get; set; }

		public string? Speciality { get; set; }

		public string? ContactNumber { get; set; }
	}
}
