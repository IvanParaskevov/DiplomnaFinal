using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Patient : User
    {


        public ICollection<LabExamination> Examinations { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<PatientExamination> PatientExaminations { get; set; }
        public Patient()
        {
            Examinations = new List<LabExamination>();
            Appointments = new List<Appointment>();
            PatientExaminations = new List<PatientExamination>();
        }
        public Patient(string fname, string secname, string lname, string username, DateTime birthdate, string email, string phone) : base(fname, secname, lname, username, birthdate, email, phone)
        {
            Examinations = new List<LabExamination>();
            Appointments = new List<Appointment>();
            PatientExaminations = new List<PatientExamination>();
        }


    }

}
