using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionAbscence.Models
{
    public class Classe
    {
        [Key]
        public int CodeClasse { get; set; }

        public string NomClasse { get; set; }

        // Foreign Key for Groupe (Many classes belong to one group)
        [ForeignKey("Groupe")]
        public int CodeGroupe { get; set; }

        // Navigation property for Groupe
        public virtual Groupe Groupe { get; set; }

        // Foreign Key for Departement (Many classes belong to one department)
        [ForeignKey("Departement")]
        public int CodeDepartement { get; set; }

        // Navigation property for Departement
        public virtual Departement Departement { get; set; }

        // Navigation property for FicheAbsence (One Classe has Many FicheAbsence)
        public virtual ICollection<FicheAbsence> FicheAbsences { get; set; }

    }
}
