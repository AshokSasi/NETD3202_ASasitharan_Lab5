using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETD3202_ASasitharan_Lab5.Models
{
    public class Patient
    {
        public int patientId { get; set; }
        public string patientfname { get; set; }
        public string patientlname { get; set; }
        public string patientphone { get; set; }

        public bool Validate(string patientfname, string patientlname, string phone)
        {
            Int64 numPhone;

            if (string.IsNullOrEmpty(patientfname) || string.IsNullOrEmpty(patientlname) || string.IsNullOrEmpty(phone) || patientfname.Length < 2 || patientlname.Length < 2 || phone.Length != 10 || Int64.TryParse(phone, out numPhone) == false)
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
