using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETD3202_ASasitharan_Lab5.Models
{
    public class Doctor
    {
        public int doctorId { get; set; }
        public string doctorfname { get; set; }
        public string doctorlname { get; set; }
        public string doctorphone { get; set; }
        public string fullname { get { return this.doctorfname + " " + this.doctorlname; } }
        public bool Validate(string doctorfname, string doctorlname, string phone)
        {
            Int64 numPhone;
      
           if ( string.IsNullOrEmpty(doctorfname) || string.IsNullOrEmpty(doctorlname) || string.IsNullOrEmpty(phone) || doctorfname.Length <2 || doctorlname.Length <2 || phone.Length != 10 || Int64.TryParse(phone,out numPhone) == false)
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
