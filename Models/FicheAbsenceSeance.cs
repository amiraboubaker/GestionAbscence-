using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionAbscence.Models
{
    public class FicheAbsenceSeance
    {
        [Key]
        public int Id { get; set; }

        // Foreign Key for FicheAbsence
        [ForeignKey("FicheAbsence")]
        public int IdFicheAbsence { get; set; }

        // Navigation property for FicheAbsence
        public virtual FicheAbsence FicheAbsence { get; set; }

        // Foreign Key for Seance
        [ForeignKey("Seance")]
        public int CodeSeance { get; set; }

        // Navigation property for Seance
        public virtual Seance Seance { get; set; }
    }
}
