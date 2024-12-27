using GestionAbscence.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class FicheAbsence
{
    [Key]
    public int IdFicheAbsence { get; set; }

    public string Description { get; set; }

    [ForeignKey("Classe")]
    public int CodeClasse { get; set; }
    public virtual Classe Classe { get; set; }

    [ForeignKey("Matiere")]
    public int CodeMatiere { get; set; }
    public virtual Matiere Matiere { get; set; }

    public virtual ICollection<LigneFicheAbsence> LigneFicheAbsences { get; set; }
    public virtual ICollection<FicheAbsenceSeance> FicheAbsenceSeances { get; set; }

    // Foreign Key for Enseignant
    [ForeignKey("Enseignant")]
    public int CodeEnseignant { get; set; }

    // Navigation property for Enseignant (Many-to-One)
    public virtual Enseignant Enseignant { get; set; }
}
