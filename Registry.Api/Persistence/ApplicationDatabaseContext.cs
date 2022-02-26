using System.Reflection;
using Registry.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Registry.Api.Persistence
{
	public class ApplicationDatabaseContext : DbContext
	{
		public DbSet<AppointmentEntity>? Appointments { get; set; }

		public DbSet<DoctorEntity>? Doctors { get; set; }

		public DbSet<PatientEntity>? Patients { get; set; }

		private readonly DatabaseSettings settings;

		public ApplicationDatabaseContext(IOptions<DatabaseSettings> settings)
		{
			this.settings = settings.Value;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
				.UseNpgsql(settings.ConnectionString)
				.UseSnakeCaseNamingConvention()
				.UseLazyLoadingProxies();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
