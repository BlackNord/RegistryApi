namespace Registry.Api.Dto.Requests
{
	public class PatientCreateRequest
	{
		public string? Name { get; set; }

		public string? Surname { get; set; }

		public DateTimeOffset BirthDate { get; set; }

		public string? ContactNumber { get; set; }
	}
}
