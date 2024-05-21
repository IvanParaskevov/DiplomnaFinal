using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class PatientExaminationManager
    {
        private readonly PatientExaminationContext patientExaminationContext;

        public PatientExaminationManager(PatientExaminationContext patientExaminationContext)
        {
            this.patientExaminationContext = patientExaminationContext;
        }

        public async Task CreateAsync(PatientExamination patient)
        {
            await patientExaminationContext.CreateAsync(patient);
        }

        public async Task<PatientExamination> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await patientExaminationContext.ReadAsync(key, useNavigationalProperties);
        }

        public async Task<ICollection<PatientExamination>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await patientExaminationContext.ReadAllAsync(useNavigationalProperties, isReadOnly);
        }

        public async Task UpdateAsync(PatientExamination patient, bool useNavigationalProperties = false)
        {
            await patientExaminationContext.UpdateAsync(patient, useNavigationalProperties);
        }

        public async Task DeleteAsync(int key)
        {
            await patientExaminationContext.DeleteAsync(key);
        }
    }
}
