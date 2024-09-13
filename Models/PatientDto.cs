using System.ComponentModel.DataAnnotations;

namespace BloodBankProject.Models
{
    public class PatientDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = "";

        [Required, MaxLength(100)]
        public string Email { get; set; } = "";

        [Required, MaxLength(100)]
        public string Contact { get; set; } = "";
        [Required, MaxLength(100)]
        public string DoctorName { get; set; } = "";

        [Required]
        public int Age { get; set; }

        [Required, MaxLength(100)]
        public string Bloodgroup { get; set; } = "";       

        [Required, MaxLength(100)]
        public string City { get; set; } = "";
        public string Address { get; set; } = "";
    }
}
