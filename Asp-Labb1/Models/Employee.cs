using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Asp_Labb1.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; } = 0;
        [Required]
        [StringLength(60)]
        public string FirstName { get; set; } = default!;
        [Required]
        [StringLength(60)]
        public string LastName { get; set; } = default!;

        public string Fullname => $"{FirstName} {LastName}";
        public string? Address { get; set; } = default!;
        
        public string? City { get; set; } = default!;
        
        public string? Email { get; set; } = default!;

        public virtual ICollection<Absence>? Absences { get; set; } //navi
    }
}
