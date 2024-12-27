using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionAbscence.Models
{
    public class LigneFicheAbsence
    {
        [Key]
        public int Id { get; set; }

        // Foreign Key for FicheAbsence
        [ForeignKey("FicheAbsence")]
        public int IdFicheAbsence { get; set; }

        // Navigation property for FicheAbsence
        public virtual FicheAbsence FicheAbsence { get; set; }

        // Foreign Key for Etudiant
        [ForeignKey("Etudiant")]
        public int IdEtudiant { get; set; }

        // Navigation property for Etudiant
        public virtual Etudiant Etudiant { get; set; }
    }
}
