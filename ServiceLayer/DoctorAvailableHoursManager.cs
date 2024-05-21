using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class DoctorAvailableHoursManager
    {
        private readonly DoctorAvailableHoursContext _doctorAvailableHoursContext;

        public DoctorAvailableHoursManager(DoctorAvailableHoursContext doctorAvailableHoursContext)
        {
            _doctorAvailableHoursContext = doctorAvailableHoursContext;
        }

        public async Task AddHours(DayOfWeek dayOfWeek, TimeOnly startTime, TimeOnly endTime, int id, string doctorId)
        {
            await _doctorAvailableHoursContext.AddHours(dayOfWeek, startTime, endTime, id, doctorId);
        }

        public async Task<List<TimeOnly?>> GetAvailableHours(string doctorId, DayOfWeek dayOfWeek)
        {
            return await _doctorAvailableHoursContext.GetAvailableHours(doctorId, dayOfWeek);
        }

        public async Task<List<DateTime>> GetAvailableDays()
        {
            return await _doctorAvailableHoursContext.GetAvailableDays();
        }

    }
}
