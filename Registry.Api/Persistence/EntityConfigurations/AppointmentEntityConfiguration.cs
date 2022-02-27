using Registry.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Registry.Api.Persistence.EntityConfigurations
{
	public class AppointmentEntityConfiguration : IEntityTypeConfiguration<AppointmentEntity>
	{
		public void Configure(EntityTypeBuilder<AppointmentEntity> builder)
		{
			builder
			.HasOne(x => x.Doctor)
			.WithMany(x => x.Appointments)
			.HasForeignKey(x => x.DoctorId);

			builder
			.HasOne(x => x.Patient)
			.WithMany(x => x.Appointments)
			.HasForeignKey(x => x.PatientId)
			.OnDelete(DeleteBehavior.SetNull);
		}
	}
}
