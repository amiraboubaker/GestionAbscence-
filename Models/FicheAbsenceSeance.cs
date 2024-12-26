﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionAbscence.Models
{
    public class FicheAbsenceSeance
    {
        [Key]
        public int CodeFicheAbsence { get; set; }

        [ForeignKey("CodeSeance")]
        public int CodeSeance { get; set; }
    }
}
