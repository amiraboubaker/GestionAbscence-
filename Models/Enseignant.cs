using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionAbscence.Models
{
    public class Enseignant
    {
        [Key]
        public int CodeEnseignant { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nom { get; set; }

        [Required]
        [MaxLength(100)]
        public string Prenom { get; set; }

        public DateTime DateRecrutement { get; set; }

        [MaxLength(200)]
        public string Adresse { get; set; }

        [EmailAddress]
        public string Mail { get; set; }

        [Phone]
        public string Tel { get; set; }

        [ForeignKey("Departement")]
        public int CodeDepartement { get; set; }
        public virtual Departement Departement { get; set; }

        [ForeignKey("Grade")]
        public int CodeGrade { get; set; }
        public virtual Grade Grade { get; set; }

        // Relation 1-N avec FicheAbsence
        public virtual ICollection<FicheAbsence> FicheAbsences { get; set; } = new List<FicheAbsence>();
    }
}
