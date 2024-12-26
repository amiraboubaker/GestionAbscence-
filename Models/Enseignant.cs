using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionAbscence.Models
{
    public class Enseignant
    {
        [Key]
        public int CodeEnseignant { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateRecrutement { get; set; }
        public string Adresse { get; set; }
        public string Mail { get; set; }
        public int Tel { get; set; }

        [ForeignKey("CodeDepartement")]
        public int CodeDepartement { get; set; }

        [ForeignKey("CodeGrade")]
        public int CodeGrade { get; set; }
    }
}
