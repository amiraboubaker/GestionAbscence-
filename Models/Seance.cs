﻿using System.ComponentModel.DataAnnotations;

namespace GestionAbscence.Models
{
    public class Seance
    {
        [Key]
        public int CodeSeance { get; set; }
        public string NomSeance { get; set; }
        public DateTime HeureDebut { get; set; }
        public DateTime HeureFin { get; set; }
    }
}