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

        [Required(ErrorMessage = "Le champ Nom est obligatoire.")]
        [MaxLength(100)]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le champ Prénom est obligatoire.")]
        [MaxLength(100)]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "La date de naissance est obligatoire.")]
        [DataType(DataType.Date)]
        public DateTime DateNaissance { get; set; }

        [Required(ErrorMessage = "Le code classe est obligatoire.")]
        [ForeignKey("Classe")]
        public int CodeClasse { get; set; }

        public virtual Classe Classe { get; set; }

        [Required(ErrorMessage = "Le numéro d'inscription est obligatoire.")]
        public int NumInscription { get; set; }

        [MaxLength(200)]
        public string Adresse { get; set; }

        [EmailAddress(ErrorMessage = "Adresse e-mail invalide.")]
        public string Mail { get; set; }

        [Phone(ErrorMessage = "Numéro de téléphone invalide.")]
        public string Tel { get; set; }

        public virtual ICollection<LigneFicheAbsence> LigneFicheAbsences { get; set; }
    }
}
