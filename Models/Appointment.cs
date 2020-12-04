using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NETD3202_ASasitharan_Lab5.Models
{
    public class Appointment
    {
        public int appointmentId { get; set; }
        public string appointmentType { get; set; }
        public DateTime appointmentDate { get; set; }

        public string doctorfname { get; set; }

        public string doctorlname { get; set; }
        public string fullname { get { return this.doctorfname + " " + this.doctorlname; } }
        public int doctorId { get; set; }
    

        public virtual Doctor Doctor { get; set; }
       
        
        public int patientId { get; set; }
        public virtual Patient Patient { get; set; }


        public bool Validate(string appointmentType)
        {
         
            if (string.IsNullOrEmpty(appointmentType))
            {

                return false;
            }
            else
            {
                return true;
            }


        }

    }
}
