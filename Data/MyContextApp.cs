using Microsoft.EntityFrameworkCore;
using GestionAbscence.Models;

namespace GestionAbscence.Data
{
    public class MyContextApp : DbContext
    {
        public MyContextApp(DbContextOptions<MyContextApp> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One-to-Many: Classe -> Departement
            modelBuilder.Entity<Classe>()
                .HasOne(c => c.Departement)
                .WithMany(d => d.Classes)
                .HasForeignKey(c => c.CodeDepartement)
                .OnDelete(DeleteBehavior.Restrict); // Restrict cascade here

            // One-to-Many: Classe -> Groupe
            modelBuilder.Entity<Classe>()
                .HasOne(c => c.Groupe)
                .WithMany(g => g.Classes)
                .HasForeignKey(c => c.CodeGroupe)
                .OnDelete(DeleteBehavior.Restrict); // Restrict cascade here

            // One-to-Many: Classe -> FicheAbsence
            modelBuilder.Entity<FicheAbsence>()
                .HasOne(f => f.Classe)
                .WithMany(c => c.FicheAbsences)
                .HasForeignKey(f => f.CodeClasse)
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-Many: FicheAbsence -> Matiere
            modelBuilder.Entity<FicheAbsence>()
                .HasOne(f => f.Matiere)
                .WithMany(m => m.FicheAbsences)
                .HasForeignKey(f => f.CodeMatiere)
                .OnDelete(DeleteBehavior.Restrict);

            // Many-to-Many: FicheAbsence <-> Etudiant (via LigneFicheAbsence)
            modelBuilder.Entity<LigneFicheAbsence>()
                .HasOne(l => l.FicheAbsence)
                .WithMany(f => f.LigneFicheAbsences)
                .HasForeignKey(l => l.IdFicheAbsence)
                .OnDelete(DeleteBehavior.Restrict); // Restrict cascade here

            modelBuilder.Entity<LigneFicheAbsence>()
                .HasOne(l => l.Etudiant)
                .WithMany(e => e.LigneFicheAbsences)
                .HasForeignKey(l => l.IdEtudiant)
                .OnDelete(DeleteBehavior.Restrict); // Restrict cascade here

            // Many-to-Many: FicheAbsence <-> Seance (via FicheAbsenceSeance)
            modelBuilder.Entity<FicheAbsenceSeance>()
                .HasOne(fas => fas.FicheAbsence)
                .WithMany(f => f.FicheAbsenceSeances)
                .HasForeignKey(fas => fas.IdFicheAbsence)
                .OnDelete(DeleteBehavior.Restrict); // Restrict cascade here

            modelBuilder.Entity<FicheAbsenceSeance>()
                .HasOne(fas => fas.Seance)
                .WithMany(s => s.FicheAbsenceSeances)
                .HasForeignKey(fas => fas.CodeSeance)
                .OnDelete(DeleteBehavior.Restrict); // Restrict cascade here

            // One-to-Many: Enseignant -> Departement
            modelBuilder.Entity<Enseignant>()
                .HasOne(e => e.Departement)
                .WithMany(d => d.Enseignants)
                .HasForeignKey(e => e.CodeDepartement)
                .OnDelete(DeleteBehavior.Restrict); // Restrict cascade here

            // One-to-Many: Enseignant -> FicheAbsence
            modelBuilder.Entity<Enseignant>()
                .HasMany(e => e.FicheAbsences)  // Enseignant can have many FicheAbsences
                .WithOne(f => f.Enseignant)  // Each FicheAbsence is linked to one Enseignant
                .HasForeignKey(f => f.CodeEnseignant)  // Foreign key in FicheAbsence
                .OnDelete(DeleteBehavior.Restrict);  // Restrict cascade delete

            modelBuilder.Entity<Grade>()
                .HasMany(g => g.Enseignants)  // Grade peut avoir plusieurs Enseignants
                .WithOne(e => e.Grade)       // Chaque Enseignant a un Grade
                .HasForeignKey(e => e.CodeGrade)  // Foreign Key dans Enseignant
                .OnDelete(DeleteBehavior.Restrict); // Empêche la suppression en cascade

            // One-to-One relationship between User and Enseignant
            modelBuilder.Entity<Enseignant>()
                .HasOne(e => e.User)
                .WithOne()
                .HasForeignKey<Enseignant>(e => e.UserId);

            // One-to-One relationship between User and Etudiant
            modelBuilder.Entity<Etudiant>()
                .HasOne(e => e.User)
                .WithOne()
                .HasForeignKey<Etudiant>(e => e.UserId);

            // One-to-One relationship between User and Admin
            modelBuilder.Entity<Admin>()
                .HasOne(a => a.User)
                .WithOne()
                .HasForeignKey<Admin>(a => a.UserId);  // Assuming UserId is the foreign key in Admin
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
        public DbSet<Admin> Admin { get; set; }
    }
}
