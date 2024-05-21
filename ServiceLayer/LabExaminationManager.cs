using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class LabExaminationManager
    {
        private readonly LabExaminationContext labExaminationContext;

        public LabExaminationManager(LabExaminationContext labExaminationContext)
        {
            this.labExaminationContext = labExaminationContext;
        }

        public async Task CreateAsync(LabExamination item)
        {
            await labExaminationContext.CreateAsync(item);
        }

        public async Task<LabExamination> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await labExaminationContext.ReadAsync(key, useNavigationalProperties, isReadOnly);
        }

        public async Task<ICollection<LabExamination>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await labExaminationContext.ReadAllAsync(useNavigationalProperties, isReadOnly);
        }

        public async Task UpdateAsync(LabExamination item, bool useNavigationalProperties = false)
        {
            await labExaminationContext.UpdateAsync(item, useNavigationalProperties);
        }

        public async Task DeleteAsync(int key)
        {
            await labExaminationContext.DeleteAsync(key);
        }



    }
}
