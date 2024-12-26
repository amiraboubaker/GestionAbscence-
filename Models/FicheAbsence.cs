using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionAbscence.Models
{
    public class FicheAbsence
    {
        [Key]
        public int CodeFicheAbsence { get; set; }
        public DateTime DateJour { get; set; }

        [ForeignKey("CodeMatiere")]
        public int CodeMatiere { get; set; }

        [ForeignKey("CodeEnseignant")]
        public int CodeEnseignant { get; set; }

        [ForeignKey("CodeClasse")]
        public int CodeClasse { get; set; }
    }
}
