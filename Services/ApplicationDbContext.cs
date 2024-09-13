using BloodBankProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace BloodBankProject.Services
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { 
        
        }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}
