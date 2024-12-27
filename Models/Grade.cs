using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionAbscence.Models
{
    public class Grade
    {
        [Key]
        public int CodeGrade { get; set; }
        public string NomGrade { get; set; }

        // Navigation property for multiple Enseignants (One-to-Many)
        public virtual ICollection<Enseignant> Enseignants { get; set; }
    }
}
