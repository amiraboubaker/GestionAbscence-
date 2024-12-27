using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace GestionAbscence.Models
{
    public class Etudiant
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }

        [ForeignKey("CodeClasse")]
        public int CodeClasse { get; set; }

        public int NumInscription { get; set; }
        public string Adresse { get; set; }
        public string Mail { get; set; }
        public int Tel { get; set; }

        // Navigation property for FicheAbsences via LigneFicheAbsence
        public virtual ICollection<LigneFicheAbsence> LigneFicheAbsences { get; set; }

        // Relationship to the User class (One-to-One)
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
