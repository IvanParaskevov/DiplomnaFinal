using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class PatientExamination
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string GeneratedId { get; set; }
        [Required]
        public string GeneratedPassword { get; set; }

        public bool AreLabResultsReady { get; set; }

        public byte[] DocumentResultPdf { get; set; }

        [ForeignKey("Patient")]
        public string PatientId { get; set; }
        public Patient Patient { get; set; }

        [ForeignKey("LabExamination")]
        public int ExaminationId { get; set; }
        public LabExamination LabExamination { get; set; }
        public PatientExamination()
        {

        }
        public PatientExamination(string generatedId, string generatedPassword, string patientId, int labExaminationId, bool results, byte[] doc)
        {
            GeneratedId = generatedId;
            GeneratedPassword = generatedPassword;
            PatientId = patientId;
            ExaminationId = labExaminationId;
            AreLabResultsReady = results;
            DocumentResultPdf = doc;
        }

    }
}
