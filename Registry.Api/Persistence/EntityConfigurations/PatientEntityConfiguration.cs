using Registry.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Registry.Api.Persistence.EntityConfigurations
{
	public class PatientEntityConfiguration : IEntityTypeConfiguration<PatientEntity>
	{
		public void Configure(EntityTypeBuilder<PatientEntity> builder)
		{
			builder
				.Property(x => x.Name)
				.HasMaxLength(20);

			builder
				.Property(x => x.Surname)
				.HasMaxLength(20);

			builder
				.Property(x => x.ContactNumber)
				.HasMaxLength(15);
		}
	}
}
