using System.ComponentModel.DataAnnotations;

namespace BloodBankProject.Models
{
    public class Donor
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = "";

        [MaxLength(100)]
        public string Email { get; set; } = "";

        [MaxLength(100)]
        public string Contact { get; set; } = "";
        public int Age { get; set; }

        [MaxLength(100)]
        public string Bloodgroup { get; set; } = "";
        public DateTime Birthdate { get; set; }

        [MaxLength(100)]
        public string City { get; set; } = "";
        public string Address { get; set; } = "";
    }
}
