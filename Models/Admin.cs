using System.ComponentModel.DataAnnotations;

namespace GestionAbscence.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required]
        [MaxLength(50)]
        public string AdminCode { get; set; } // Specific property for Admin
    }
}
