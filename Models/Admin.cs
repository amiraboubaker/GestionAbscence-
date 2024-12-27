using System.ComponentModel.DataAnnotations.Schema;

namespace GestionAbscence.Models
{
    public class Admin : User
    {
        public string AdminCode { get; set; } // Specific property for Admins, if necessary

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
