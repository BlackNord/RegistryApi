using Registry.Api.Persistence;
using Registry.Api.Repositories;
using Registry.Api.Services;
using Registry.Api.Services.Interfaces;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpOverrides;
using Registry.Api.Integration.Integration;
using Registry.Api.Integration.Service.Interfaces;
using Registry.Api.Integration.Service;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

//Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "google_auth_credentials.json");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOptions();

builder.Services.Configure<GCSettings>(configuration.GetSection(nameof(GCSettings)));
builder.Services.AddScoped<IBillingService, BillingService>();

builder.Services.AddHttpLogging(options =>
{
	options.LoggingFields = HttpLoggingFields.Request;
});

builder.Services.Configure<DatabaseSettings>(configuration.GetSection(nameof(DatabaseSettings)));

builder.Services.AddScoped<DbContext, ApplicationDatabaseContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));

builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

var app = builder.Build();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
	ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpLogging();
app.UseAuthorization();
app.MapControllers();

app.Run();
