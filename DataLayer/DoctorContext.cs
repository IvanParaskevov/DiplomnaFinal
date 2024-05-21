using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DoctorContext : IDb<Doctor, string>
    {
        private readonly MedicalDbContext dbContext;

        public DoctorContext(MedicalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(Doctor item)
        {
            try
            {
                dbContext.Doctors.Add(item);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Doctor> ReadAsync(string key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Doctor> query = dbContext.Doctors;

                if (useNavigationalProperties)
                {
                    query = query.Include(a => a.Appointments);


                }

                if (isReadOnly)
                {
                    query = query.AsNoTrackingWithIdentityResolution();
                }

                return await query.FirstOrDefaultAsync(a => a.Id == key);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Doctor>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Doctor> query = dbContext.Doctors;

                if (useNavigationalProperties)
                {
                    query = query.Include(a => a.Appointments);

                }

                if (isReadOnly)
                {
                    query = query.AsNoTrackingWithIdentityResolution();
                }

                return await query.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(Doctor item, bool useNavigationalProperties = false)
        {
            try
            {
                dbContext.Doctors.Update(item);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAsync(string key)
        {
            try
            {
                Doctor doctorFromDb = await ReadAsync(key, false, false);

                if (doctorFromDb is null)
                {
                    throw new ArgumentException("Doctor with that Id does not exist!");
                }

                dbContext.Doctors.Remove(doctorFromDb);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
