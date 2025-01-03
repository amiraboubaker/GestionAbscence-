﻿// <auto-generated />
using System;
using GestionAbscence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionAbscence.Migrations
{
    [DbContext(typeof(MyContextApp))]
    [Migration("20241226121606_AddManyToManyRelationFicheAbsenceSeance")]
    partial class AddManyToManyRelationFicheAbsenceSeance
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestionAbscence.Models.Classe", b =>
                {
                    b.Property<int>("CodeClasse")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodeClasse"));

                    b.Property<int>("CodeDepartement")
                        .HasColumnType("int");

                    b.Property<int>("CodeGroupe")
                        .HasColumnType("int");

                    b.Property<string>("NomClasse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodeClasse");

                    b.HasIndex("CodeDepartement");

                    b.HasIndex("CodeGroupe");

                    b.ToTable("Classe");
                });

            modelBuilder.Entity("GestionAbscence.Models.Departement", b =>
                {
                    b.Property<int>("CodeDepartement")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodeDepartement"));

                    b.Property<string>("NomDepartement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodeDepartement");

                    b.ToTable("Departement");
                });

            modelBuilder.Entity("GestionAbscence.Models.Enseignant", b =>
                {
                    b.Property<int>("CodeEnseignant")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodeEnseignant"));

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CodeDepartement")
                        .HasColumnType("int");

                    b.Property<int>("CodeGrade")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRecrutement")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tel")
                        .HasColumnType("int");

                    b.HasKey("CodeEnseignant");

                    b.ToTable("Enseignant");
                });

            modelBuilder.Entity("GestionAbscence.Models.Etudiant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CodeClasse")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumInscription")
                        .HasColumnType("int");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Etudiant");
                });

            modelBuilder.Entity("GestionAbscence.Models.FicheAbsence", b =>
                {
                    b.Property<int>("IdFicheAbsence")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFicheAbsence"));

                    b.Property<int>("CodeClasse")
                        .HasColumnType("int");

                    b.Property<int>("CodeMatiere")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdFicheAbsence");

                    b.HasIndex("CodeClasse")
                        .IsUnique();

                    b.HasIndex("CodeMatiere")
                        .IsUnique();

                    b.ToTable("FicheAbsence");
                });

            modelBuilder.Entity("GestionAbscence.Models.FicheAbsenceSeance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CodeSeance")
                        .HasColumnType("int");

                    b.Property<int>("IdFicheAbsence")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CodeSeance");

                    b.HasIndex("IdFicheAbsence");

                    b.ToTable("FicheAbsenceSeance");
                });

            modelBuilder.Entity("GestionAbscence.Models.Grade", b =>
                {
                    b.Property<int>("CodeGrade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodeGrade"));

                    b.Property<string>("NomGrade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodeGrade");

                    b.ToTable("Grade");
                });

            modelBuilder.Entity("GestionAbscence.Models.Groupe", b =>
                {
                    b.Property<int>("CodeGroupe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodeGroupe"));

                    b.Property<string>("NomGroupe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodeGroupe");

                    b.ToTable("Groupe");
                });

            modelBuilder.Entity("GestionAbscence.Models.LigneFicheAbsence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdEtudiant")
                        .HasColumnType("int");

                    b.Property<int>("IdFicheAbsence")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdEtudiant");

                    b.HasIndex("IdFicheAbsence");

                    b.ToTable("LigneFicheAbsence");
                });

            modelBuilder.Entity("GestionAbscence.Models.Matiere", b =>
                {
                    b.Property<int>("CodeMatiere")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodeMatiere"));

                    b.Property<int>("NbreHeureCoursParSemaine")
                        .HasColumnType("int");

                    b.Property<int>("NbreHeureTDParSemaine")
                        .HasColumnType("int");

                    b.Property<int>("NbreHeureTPParSemaine")
                        .HasColumnType("int");

                    b.Property<string>("NomMatiere")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodeMatiere");

                    b.ToTable("Matiere");
                });

            modelBuilder.Entity("GestionAbscence.Models.Seance", b =>
                {
                    b.Property<int>("CodeSeance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodeSeance"));

                    b.Property<DateTime>("HeureDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HeureFin")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomSeance")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodeSeance");

                    b.ToTable("Seance");
                });

            modelBuilder.Entity("GestionAbscence.Models.Classe", b =>
                {
                    b.HasOne("GestionAbscence.Models.Departement", "Departement")
                        .WithMany("Classes")
                        .HasForeignKey("CodeDepartement")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionAbscence.Models.Groupe", "Groupe")
                        .WithMany("Classes")
                        .HasForeignKey("CodeGroupe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departement");

                    b.Navigation("Groupe");
                });

            modelBuilder.Entity("GestionAbscence.Models.FicheAbsence", b =>
                {
                    b.HasOne("GestionAbscence.Models.Classe", "Classe")
                        .WithOne("FicheAbsence")
                        .HasForeignKey("GestionAbscence.Models.FicheAbsence", "CodeClasse")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionAbscence.Models.Matiere", "Matiere")
                        .WithOne("FicheAbsence")
                        .HasForeignKey("GestionAbscence.Models.FicheAbsence", "CodeMatiere")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classe");

                    b.Navigation("Matiere");
                });

            modelBuilder.Entity("GestionAbscence.Models.FicheAbsenceSeance", b =>
                {
                    b.HasOne("GestionAbscence.Models.Seance", "Seance")
                        .WithMany("FicheAbsenceSeances")
                        .HasForeignKey("CodeSeance")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionAbscence.Models.FicheAbsence", "FicheAbsence")
                        .WithMany("FicheAbsenceSeances")
                        .HasForeignKey("IdFicheAbsence")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FicheAbsence");

                    b.Navigation("Seance");
                });

            modelBuilder.Entity("GestionAbscence.Models.LigneFicheAbsence", b =>
                {
                    b.HasOne("GestionAbscence.Models.Etudiant", "Etudiant")
                        .WithMany("LigneFicheAbsences")
                        .HasForeignKey("IdEtudiant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionAbscence.Models.FicheAbsence", "FicheAbsence")
                        .WithMany("LigneFicheAbsences")
                        .HasForeignKey("IdFicheAbsence")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Etudiant");

                    b.Navigation("FicheAbsence");
                });

            modelBuilder.Entity("GestionAbscence.Models.Classe", b =>
                {
                    b.Navigation("FicheAbsence")
                        .IsRequired();
                });

            modelBuilder.Entity("GestionAbscence.Models.Departement", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("GestionAbscence.Models.Etudiant", b =>
                {
                    b.Navigation("LigneFicheAbsences");
                });

            modelBuilder.Entity("GestionAbscence.Models.FicheAbsence", b =>
                {
                    b.Navigation("FicheAbsenceSeances");

                    b.Navigation("LigneFicheAbsences");
                });

            modelBuilder.Entity("GestionAbscence.Models.Groupe", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("GestionAbscence.Models.Matiere", b =>
                {
                    b.Navigation("FicheAbsence")
                        .IsRequired();
                });

            modelBuilder.Entity("GestionAbscence.Models.Seance", b =>
                {
                    b.Navigation("FicheAbsenceSeances");
                });
#pragma warning restore 612, 618
        }
    }
}
