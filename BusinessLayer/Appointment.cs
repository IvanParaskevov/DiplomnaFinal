using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public AppointmentReason Reason { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }
        [AllowNull]
        public TimeOnly? StartTime { get; set; }
        [AllowNull]
        public TimeOnly? EndTime { get; set; }

        [ForeignKey("Doctor")]
        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [ForeignKey("Patient")]
        public string PatientId { get; set; }
        public Patient Patient { get; set; }

        public Appointment()
        {

        }

        public Appointment(int id, AppointmentReason reason, string description, DateTime date, TimeOnly? startTime, TimeOnly? endTime, Doctor doctor, Patient patient)
        {
            Id = id;
            Reason = reason;
            Description = description;
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
            Doctor = doctor;
            DoctorId = doctor.Id;
            Patient = patient;
            PatientId = patient.Id;
        }
        public enum AppointmentReason
        {
            Първичен_преглед, Издаване_на_медицинско, Издаване_на_рецепта, Консултация, Профилактичен_преглед
        }

    }
}
