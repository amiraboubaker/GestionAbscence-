using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionAbscence.Models
{
    public class Etudiant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nom { get; set; }

        [Required]
        [MaxLength(100)]
        public string Prenom { get; set; }

        public DateTime DateNaissance { get; set; }

        [ForeignKey("Classe")]
        public int CodeClasse { get; set; }
        public virtual Classe Classe { get; set; }

        [Required]
        public int NumInscription { get; set; }

        [MaxLength(200)]
        public string Adresse { get; set; }

        [EmailAddress]
        public string Mail { get; set; }

        [Phone]
        public string Tel { get; set; }

        // Assurez-vous que la propriété suivante est correctement écrite
        public virtual ICollection<LigneFicheAbsence> LigneFicheAbsences { get; set; }
    }
}
