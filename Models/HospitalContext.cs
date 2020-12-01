using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NETD3202_ASasitharan_Lab5.Models
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {

        }

        public DbSet<Appointment> appointment { get; set; }
        public DbSet<Doctor> doctors { get; set; }
        public DbSet<Patient> patients { get; set; }
    }
}
