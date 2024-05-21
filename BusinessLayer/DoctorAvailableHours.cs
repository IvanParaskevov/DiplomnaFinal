using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DoctorAvailableHours
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; } // monday...friday
        [AllowNull]
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }

        [ForeignKey("Doctor")]
        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public DoctorAvailableHours()
        {

        }

        public DoctorAvailableHours(DayOfWeek dayOfWeek, TimeOnly? startTime, TimeOnly? endTime, int id, string doctorId)
        {
            DayOfWeek = dayOfWeek;
            StartTime = startTime;
            EndTime = endTime;
            Id = id;
            DoctorId = doctorId;
        }
    }
}
