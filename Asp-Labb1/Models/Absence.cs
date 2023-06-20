using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.ComponentModel;

namespace Asp_Labb1.Models
{
    public class Absence
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AbsenceID { get; set; } = 0;

        [ForeignKey("Absencetypes")]
        public int FK_AbsenceTypeID { get; set; }
        public virtual AbsenceType? Absencetypes { get; set; } //navi

        [ForeignKey("Employees")]
        public int FK_EmployeeID { get; set; }
        public virtual Employee? Employees { get; set; } //navi

        public DateTime TimeCreated { get; set; }
        
        public DateTime StartOfAbsence { get; set; }
        
        public DateTime EndOfAbsence { get; set; }

        [NotMapped]
        [DisplayName("Number Of Days Abscent")]
        public int daysAbscent => (EndOfAbsence - StartOfAbsence).Days;

        


    }
}
