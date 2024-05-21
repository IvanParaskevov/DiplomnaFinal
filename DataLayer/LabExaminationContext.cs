using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LabExaminationContext : IDb<LabExamination, int>
    {
        private readonly MedicalDbContext dbContext;

        public LabExaminationContext(MedicalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(LabExamination item)
        {
            try
            {
                dbContext.LabExaminations.Add(item);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<LabExamination> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<LabExamination> query = dbContext.LabExaminations;

                if (useNavigationalProperties)
                {
                    query = query.Include(a => a.Patient);


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

        public async Task<List<LabExamination>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<LabExamination> query = dbContext.LabExaminations;

                if (useNavigationalProperties)
                {
                    query = query.Include(a => a.Patient);


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

        public async Task UpdateAsync(LabExamination item, bool useNavigationalProperties = false)
        {
            try
            {
                dbContext.LabExaminations.Update(item);
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
                LabExamination labExaminationFromDb = await ReadAsync(key, false, false);

                if (labExaminationFromDb is null)
                {
                    throw new ArgumentException("LabExamination with that Id does not exist!");
                }

                dbContext.LabExaminations.Remove(labExaminationFromDb);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
