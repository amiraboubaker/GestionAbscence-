using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace GestionAbscence.Models
{
    public class Groupe
    {
        [Key]
        public int CodeGroupe { get; set; }

        public string NomGroupe { get; set; }

        // One Groupe can have many Classes (1-to-many relationship)
        public virtual ICollection<Classe> Classes { get; set; } = new List<Classe>();
    }
}
