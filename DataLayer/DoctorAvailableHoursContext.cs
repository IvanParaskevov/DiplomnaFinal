using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DoctorAvailableHoursContext
    {
        private readonly MedicalDbContext context;

        public DoctorAvailableHoursContext(MedicalDbContext context)
        {
            this.context = context;
        }

        public async Task AddHours(DayOfWeek dayOfWeek, TimeOnly startTime, TimeOnly endTime, int id, string doctorId)
        {
            DoctorAvailableHours dah = new DoctorAvailableHours(dayOfWeek, startTime, endTime, id, doctorId);
            context.DoctorAvailableHours.Add(dah);
            await context.SaveChangesAsync();
        }

        public async Task<List<TimeOnly?>> GetAvailableHours(string doctorId, DayOfWeek dayOfWeek)
        {
            return await context.DoctorAvailableHours.Where(dah => dah.DoctorId == doctorId && dah.DayOfWeek == dayOfWeek)
                .Select(dah => dah.StartTime).ToListAsync();
        }

        public async Task<List<DateTime>> GetAvailableDays()
        {
            // Get distinct days of the week that have available hours
            var availableDays = await context.DoctorAvailableHours
                .Select(dah => dah.DayOfWeek)
                .Distinct()
                .ToListAsync();

            // Create a list to store available dates
            List<DateTime> availableDates = new List<DateTime>();

            // Get the current date
            DateTime currentDate = DateTime.Today;

            // Loop through each available day and find the next occurrence from the current date
            foreach (var dayOfWeek in availableDays)
            {
                // Find the next occurrence of the day of the week from the current date
                DateTime nextOccurrence = currentDate.AddDays(((int)dayOfWeek - (int)currentDate.DayOfWeek + 7) % 7);

                // Add the next occurrence to the list of available dates
                availableDates.Add(nextOccurrence);
            }

            return availableDates;
        }

    }
}
