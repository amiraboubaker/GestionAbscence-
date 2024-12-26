using System.ComponentModel.DataAnnotations;

namespace GestionAbscence.Models
{
    public class Groupe
    {
        [Key]
        public int CodeGroupe { get; set; }
        public string NomGroupe { get; set; }
    }
}
