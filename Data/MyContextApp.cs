using GestionAbscence.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionAbscence.Data
{
    public class MyContextApp : DbContext
    {
        // Constructor for runtime DI
        public MyContextApp(DbContextOptions<MyContextApp> options) : base(options)
        {
        }

        // DbSets for your entities
        public DbSet<Classe> Classe { get; set; }
        public DbSet<Departement> Departement { get; set; } 
        public DbSet<Enseignant> Enseignant { get; set; }
        public DbSet<Etudiant> Etudiant { get; set; }
        public DbSet<FicheAbsence> FicheAbsence { get; set; }
        public DbSet<FicheAbsenceSeance> FicheAbsenceSeance { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<Groupe> Groupe { get; set; }
        public DbSet<LigneFicheAbsence> LigneFicheAbsence { get; set; }
        public DbSet<Matiere> Matiere { get; set; }
        public DbSet<Seance> Seance { get; set; }
    }
}
