using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Asp_Labb1.Models
{
    public class AbsenceType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AbsenceTypeID { get; set; }

        [Required]
        [StringLength(60)]
        [DisplayName("Absence Type")]
        public string TypeOfAbsence { get; set; }

        public virtual ICollection<Absence>? Absences { get; set; } //navi

    }
}
