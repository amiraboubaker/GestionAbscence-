using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

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

        [ForeignKey("Departement")]
        public int CodeDepartement { get; set; }
        public virtual Departement Departement { get; set; }

        [ForeignKey("Grade")]
        public int CodeGrade { get; set; }
        public virtual Grade Grade { get; set; }

        // Navigation property for FicheAbsences (One-to-Many)
        public virtual ICollection<FicheAbsence> FicheAbsences { get; set; }

        // Relationship to the User class (One-to-One)
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
