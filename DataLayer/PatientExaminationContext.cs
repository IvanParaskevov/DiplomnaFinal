using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PatientExaminationContext
    {
        private readonly MedicalDbContext dbContext;

        public PatientExaminationContext(MedicalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(PatientExamination item)
        {
            try
            {
                dbContext.PatientExaminations.Add(item);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAsync(int key)
        {
            try
            {
                PatientExamination data = await ReadAsync(key, false, false);

                if (data == null)
                {
                    throw new ArgumentException("A message with that key does not exist!");
                }

                dbContext.PatientExaminations.Remove(data);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<PatientExamination>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<PatientExamination> query = dbContext.PatientExaminations;

                if (useNavigationalProperties)
                {
                    query = query.Include(a => a.LabExamination)
                                 .Include(a => a.Patient);

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

        public async Task<PatientExamination> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<PatientExamination> query = dbContext.PatientExaminations;

                if (useNavigationalProperties)
                {
                    query = query.Include(a => a.Patient)
                                 .Include(a => a.LabExamination);

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

        public async Task UpdateAsync(PatientExamination item, bool useNavigationalProperties = false)
        {
            try
            {
                dbContext.PatientExaminations.Update(item);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
