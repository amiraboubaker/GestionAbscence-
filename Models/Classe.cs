using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionAbscence.Models
{
    public class Classe
    {
        [Key]
        public int CodeClasse { get; set; }
        public string NomClasse { get; set; }

        [ForeignKey("CodeGroupe")]
        public string CodeGroupe { get; set; }

        [ForeignKey("CodeDepartement")]
        public int CodeDepartement { get; set; }
    }
}
