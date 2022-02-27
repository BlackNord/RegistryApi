namespace Registry.Api.Dto.Requests
{
	public class DoctorCreateRequest
	{
		public string? Name { get; set; }

		public string? Surname { get; set; }

		public string? Speciality { get; set; }

		public string? ContactNumber { get; set; }
	}
}
