using System.ComponentModel.DataAnnotations;

namespace GestionAbscence.Models
{
    public class Departement
    {
        [Key]
        public int CodeDepartement { get; set; }
        public string NomDepartement { get; set; }
    }
}
