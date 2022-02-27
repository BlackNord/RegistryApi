﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Registry.Api.Persistence;

#nullable disable

namespace Registry.Api.Migrations
{
    [DbContext(typeof(ApplicationDatabaseContext))]
    [Migration("20220226200730_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Registry.Api.Entities.AppointmentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("AppointmentDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("appointment_date");

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer")
                        .HasColumnName("doctor_id");

                    b.Property<bool>("IsAssigned")
                        .HasColumnType("boolean")
                        .HasColumnName("is_assigned");

                    b.Property<int?>("PatientId")
                        .HasColumnType("integer")
                        .HasColumnName("patient_id");

                    b.HasKey("Id")
                        .HasName("pk_appointments");

                    b.HasIndex("DoctorId")
                        .HasDatabaseName("ix_appointments_doctor_id");

                    b.HasIndex("PatientId")
                        .HasDatabaseName("ix_appointments_patient_id");

                    b.ToTable("appointments", (string)null);
                });

            modelBuilder.Entity("Registry.Api.Entities.DoctorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactNumber")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("contact_number");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name");

                    b.Property<string>("Speciality")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("speciality");

                    b.Property<string>("Surname")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("surname");

                    b.HasKey("Id")
                        .HasName("pk_doctors");

                    b.ToTable("doctors", (string)null);
                });

            modelBuilder.Entity("Registry.Api.Entities.PatientEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("BirthDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("birth_date");

                    b.Property<string>("ContactNumber")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("contact_number");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name");

                    b.Property<string>("Surname")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("surname");

                    b.HasKey("Id")
                        .HasName("pk_patients");

                    b.ToTable("patients", (string)null);
                });

            modelBuilder.Entity("Registry.Api.Entities.AppointmentEntity", b =>
                {
                    b.HasOne("Registry.Api.Entities.DoctorEntity", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_appointments_doctors_doctor_id");

                    b.HasOne("Registry.Api.Entities.PatientEntity", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("fk_appointments_patients_patient_id");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Registry.Api.Entities.DoctorEntity", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Registry.Api.Entities.PatientEntity", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
