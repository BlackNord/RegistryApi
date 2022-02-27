namespace Registry.Api.Dto.Responses
{
	public class PatientResponse
	{
		public int Id { get; set; }

		public string? Name { get; set; }

		public string? Surname { get; set; }

		public DateTimeOffset BirthDate { get; set; }

		public string? ContactNumber { get; set; }
	}
}
