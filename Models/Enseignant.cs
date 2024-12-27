using GestionAbscence.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

public class Enseignant
{
    [Key]
    public int CodeEnseignant { get; set; }

    public string Nom { get; set; }
    public string Prenom { get; set; }
    public DateTime DateRecrutement { get; set; }
    public string Adresse { get; set; }
    public string Mail { get; set; }
    public int Tel { get; set; }

    [ForeignKey("Departement")]
    public int CodeDepartement { get; set; }
    public virtual Departement Departement { get; set; }

    [ForeignKey("Grade")]
    public int CodeGrade { get; set; }

    // Navigation property for Grade (Many-to-One)
    public virtual Grade Grade { get; set; }

    // Navigation property for multiple FicheAbsences (One-to-Many)
    public virtual ICollection<FicheAbsence> FicheAbsences { get; set; }
}
