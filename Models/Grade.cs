using System.ComponentModel.DataAnnotations;

namespace GestionAbscence.Models
{
    public class Grade
    {
        [Key]
        public int CodeGrade { get; set; }
        public string NomGrade { get; set; }
    }
}
