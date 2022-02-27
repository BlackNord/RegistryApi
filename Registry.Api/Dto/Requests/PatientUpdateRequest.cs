namespace Registry.Api.Dto.Requests
{
	public class PatientUpdateRequest
	{
		public int Id { get; set; }

		public string? Name { get; set; }

		public string? Surname { get; set; }

		public DateTimeOffset BirthDate { get; set; }

		public string? ContactNumber { get; set; }
	}
}
