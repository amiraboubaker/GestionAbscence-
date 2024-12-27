using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace GestionAbscence.Models
{
    public class Departement
    {
        [Key]
        public int CodeDepartement { get; set; }

        public string NomDepartement { get; set; }

        // One Departement can have many Classes (1-to-many relationship)
        public virtual ICollection<Classe> Classes { get; set; } = new List<Classe>();

        // One Departement can have many Enseignants
        public virtual ICollection<Enseignant> Enseignants { get; set; } = new List<Enseignant>();
    }
}
