using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class LabExamination
    {
        [Key]
        public int Id { get; set; }
        //времето за да излязат резултатите(дни)

        public int Days { get; set; }

        [Required]
        public string Description { get; set; }


        [Column(TypeName = "decimal(7,2)")]
        public decimal Price { get; set; }
        [Required]
        public TypeExamination Type { get; set; }

        [ForeignKey("Patient")]
        [Required]
        public string PatientId { get; set; }
        public Patient Patient { get; set; }

        public ICollection<PatientExamination> PatientExaminations { get; set; }

        public LabExamination()
        {
            PatientExaminations = new List<PatientExamination>();
        }

        public LabExamination(int id, int days, string description, decimal price, TypeExamination type, Patient patient)
        {
            Id = id;
            Days = days;
            Price = price;
            Type = type;
            Patient = patient;
        }

        public enum TypeExamination
        {
            Кръв, Урина, Хормони, Алергени, Токсикологични, Генетични
        }
    }
}
