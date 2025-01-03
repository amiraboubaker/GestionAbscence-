﻿using System.ComponentModel.DataAnnotations;

namespace GestionAbscence.Models
{
    public class Matiere
    {
        [Key]
        public int CodeMatiere { get; set; }

        public string NomMatiere { get; set; }

        public int NbreHeureCoursParSemaine { get; set; }

        public int NbreHeureTDParSemaine { get; set; }

        public int NbreHeureTPParSemaine { get; set; }

        // Navigation property for FicheAbsence (One Matiere has Many FicheAbsence)
        public virtual ICollection<FicheAbsence> FicheAbsences { get; set; }

    }
}
