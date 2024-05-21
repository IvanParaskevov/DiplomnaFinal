using BusinessLayer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MedicalDbContext : IdentityDbContext<User>
    {
        public MedicalDbContext() : base()
        {

        }

        public MedicalDbContext(DbContextOptions<MedicalDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-9UR8KMA\\SQLEXPRESS;Database=MedicalCityCentreDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Seed();



            modelBuilder.Entity<DoctorAvailableHours>().HasKey(dah => new { dah.Id, dah.DoctorId });



            modelBuilder.Entity<PatientExamination>()
        .HasKey(pe => pe.Id);

            modelBuilder.Entity<PatientExamination>()
                .HasOne(pe => pe.Patient)
                .WithMany(p => p.PatientExaminations)
                .HasForeignKey(pe => pe.PatientId);

            modelBuilder.Entity<PatientExamination>()
                .HasOne(pe => pe.LabExamination)
                .WithMany(le => le.PatientExaminations)
                .HasForeignKey(pe => pe.ExaminationId);

            /*    modelBuilder.Entity<DoctorTakenAppointments>()
                    .HasOne(dta => dta.Appointment)
                    .WithMany()
                    .HasForeignKey(dta => dta.AppointmentId)
                    .IsRequired();

                modelBuilder.Entity<DoctorTakenAppointments>()
                    .HasOne(dta => dta.Doctor)
                    .WithMany()
                    .HasForeignKey(dta => dta.DoctorId)
                    .IsRequired();*/



            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorAvailableHours> DoctorAvailableHours { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<LabExamination> LabExaminations { get; set; }
        public DbSet<PatientExamination> PatientExaminations { get; set; }

    }
}
