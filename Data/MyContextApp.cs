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

            // Restrict cascade deletes for all relationships to avoid accidental deletions
            modelBuilder.Entity<Classe>()
                .HasOne(c => c.Departement)
                .WithMany(d => d.Classes)
                .HasForeignKey(c => c.CodeDepartement)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Classe>()
                .HasOne(c => c.Groupe)
                .WithMany(g => g.Classes)
                .HasForeignKey(c => c.CodeGroupe)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FicheAbsence>()
                .HasOne(f => f.Classe)
                .WithMany(c => c.FicheAbsences)
                .HasForeignKey(f => f.CodeClasse)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FicheAbsence>()
                .HasOne(f => f.Matiere)
                .WithMany(m => m.FicheAbsences)
                .HasForeignKey(f => f.CodeMatiere)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LigneFicheAbsence>()
                .HasOne(l => l.FicheAbsence)
                .WithMany(f => f.LigneFicheAbsences)
                .HasForeignKey(l => l.IdFicheAbsence)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LigneFicheAbsence>()
                .HasOne(l => l.Etudiant)
                .WithMany(e => e.LigneFicheAbsences)
                .HasForeignKey(l => l.IdEtudiant)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FicheAbsenceSeance>()
                .HasOne(fas => fas.FicheAbsence)
                .WithMany(f => f.FicheAbsenceSeances)
                .HasForeignKey(fas => fas.IdFicheAbsence)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FicheAbsenceSeance>()
                .HasOne(fas => fas.Seance)
                .WithMany(s => s.FicheAbsenceSeances)
                .HasForeignKey(fas => fas.CodeSeance)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Enseignant>()
                .HasOne(e => e.Departement)
                .WithMany(d => d.Enseignants)
                .HasForeignKey(e => e.CodeDepartement)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Enseignant>()
                .HasMany(e => e.FicheAbsences)
                .WithOne(f => f.Enseignant)
                .HasForeignKey(f => f.CodeEnseignant)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Grade>()
                .HasMany(g => g.Enseignants)
                .WithOne(e => e.Grade)
                .HasForeignKey(e => e.CodeGrade)
                .OnDelete(DeleteBehavior.Restrict);
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
        public DbSet<User> User { get; set; }
        public DbSet<Admin> Admin { get; set; }
    }
}
