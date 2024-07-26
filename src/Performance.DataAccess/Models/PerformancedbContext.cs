using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Performance.DataAccess.Models;

public partial class PerformancedbContext : DbContext
{
    public PerformancedbContext()
    {
    }

    public PerformancedbContext(DbContextOptions<PerformancedbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Additionalindicator> Additionalindicators { get; set; }

    public virtual DbSet<Anuallycompetence> Anuallycompetences { get; set; }

    public virtual DbSet<Aspek> Aspeks { get; set; }

    public virtual DbSet<Basiccompetence> Basiccompetences { get; set; }

    public virtual DbSet<Indicator> Indicators { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Responsibilityareaindicator> Responsibilityareaindicators { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Subaspek> Subaspeks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Workmainindicator> Workmainindicators { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Additionalindicator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("additionalindicator_pkey");

            entity.ToTable("additionalindicator");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.IndikatorTotalValue).HasColumnName("indikator_total_value");
            entity.Property(e => e.Period).HasColumnName("period");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Anuallycompetence>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("anuallycompetences_pkey");

            entity.ToTable("anuallycompetences");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AdditionalindicatorId).HasColumnName("additionalindicator_id");
            entity.Property(e => e.AppraisalApprovalDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("appraisal_approval_date");
            entity.Property(e => e.AppraisalComment)
                .HasColumnType("character varying")
                .HasColumnName("appraisal_comment");
            entity.Property(e => e.AppraisalCommentDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("appraisal_comment_date");
            entity.Property(e => e.BasiccompetencesId).HasColumnName("basiccompetences_id");
            entity.Property(e => e.EmployeeApprovalDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("employee_approval_date");
            entity.Property(e => e.EmployeeComment)
                .HasColumnType("character varying")
                .HasColumnName("employee_comment");
            entity.Property(e => e.EmployeeCommentDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("employee_comment_date");
            entity.Property(e => e.NilaiUntukKerjaTotalWorkmainindicator).HasColumnName("nilai_untuk_kerja_total_workmainindicator");
            entity.Property(e => e.Period).HasColumnName("period");
            entity.Property(e => e.ResponsibilityareaindicatorId).HasColumnName("responsibilityareaindicator_id");
            entity.Property(e => e.SupervisorApprovalDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("supervisor_approval_date");
            entity.Property(e => e.TotalNilaiAkhirTahun).HasColumnName("total_nilai_akhir_tahun");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Additionalindicator).WithMany(p => p.Anuallycompetences)
                .HasForeignKey(d => d.AdditionalindicatorId)
                .HasConstraintName("anuallycompetences_additionalindicator_id_fkey");

            entity.HasOne(d => d.Basiccompetences).WithMany(p => p.Anuallycompetences)
                .HasForeignKey(d => d.BasiccompetencesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("anuallycompetences_basiccompetences_id_fkey");

            entity.HasOne(d => d.Responsibilityareaindicator).WithMany(p => p.Anuallycompetences)
                .HasForeignKey(d => d.ResponsibilityareaindicatorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("anuallycompetences_responsibilityareaindicator_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Anuallycompetences)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("anuallycompetences_user_id_fkey");
        });

        modelBuilder.Entity<Aspek>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("aspek_pkey");

            entity.ToTable("aspek");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AspekDescription)
                .HasColumnType("character varying")
                .HasColumnName("aspek_description");
            entity.Property(e => e.AspekName)
                .HasColumnType("character varying")
                .HasColumnName("aspek_name");
            entity.Property(e => e.Bobot).HasColumnName("bobot");
            entity.Property(e => e.NilaiUntukKerja).HasColumnName("nilai_untuk_kerja");
            entity.Property(e => e.ResponsibilityareaindicatorId).HasColumnName("responsibilityareaindicator_id");
            entity.Property(e => e.TingkatUntukKerja).HasColumnName("tingkat_untuk_kerja");

            entity.HasOne(d => d.Responsibilityareaindicator).WithMany(p => p.Aspeks)
                .HasForeignKey(d => d.ResponsibilityareaindicatorId)
                .HasConstraintName("aspek_responsibilityareaindicator_id_fkey");
        });

        modelBuilder.Entity<Basiccompetence>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("basiccompetences_pkey");

            entity.ToTable("basiccompetences");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CountinousImprovement)
                .HasColumnType("character varying")
                .HasColumnName("countinous_improvement");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerFocus)
                .HasColumnType("character varying")
                .HasColumnName("customer_focus");
            entity.Property(e => e.Integrity)
                .HasColumnType("character varying")
                .HasColumnName("integrity");
            entity.Property(e => e.Period).HasColumnName("period");
            entity.Property(e => e.Teamwork)
                .HasColumnType("character varying")
                .HasColumnName("teamwork");
            entity.Property(e => e.TotalValue).HasColumnName("total_value");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.WorkExcellent)
                .HasColumnType("character varying")
                .HasColumnName("work_excellent");
        });

        modelBuilder.Entity<Indicator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("indicator_pkey");

            entity.ToTable("indicator");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Additionalindicator).HasColumnName("additionalindicator");
            entity.Property(e => e.IndicatorName)
                .HasColumnType("character varying")
                .HasColumnName("indicator_name");
            entity.Property(e => e.IndicatorType)
                .HasColumnType("character varying")
                .HasColumnName("indicator_type");
            entity.Property(e => e.Value).HasColumnName("value");

            entity.HasOne(d => d.AdditionalindicatorNavigation).WithMany(p => p.Indicators)
                .HasForeignKey(d => d.Additionalindicator)
                .HasConstraintName("indicator_additionalindicator_fkey");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("profile_pkey");

            entity.ToTable("profile");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.Birthdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("birthdate");
            entity.Property(e => e.Department)
                .HasColumnType("character varying")
                .HasColumnName("department");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasColumnType("character varying")
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasColumnType("character varying")
                .HasColumnName("last_name");
            entity.Property(e => e.Nik)
                .HasColumnType("character varying")
                .HasColumnName("nik");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");

            entity.HasOne(d => d.User).WithOne(p => p.Profile)
                .HasForeignKey<Profile>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("profile_user_id_fkey");
        });

        modelBuilder.Entity<Responsibilityareaindicator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("responsibilityareaindicator_pkey");

            entity.ToTable("responsibilityareaindicator");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.NilaiUntukKerjaTotal).HasColumnName("nilai_untuk_kerja_total");
            entity.Property(e => e.Period).HasColumnName("period");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Roles_pkey");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Subaspek>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("subaspek_pkey");

            entity.ToTable("subaspek");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AspekId).HasColumnName("aspek_id");
            entity.Property(e => e.SubaspekAktual).HasColumnName("subaspek_aktual");
            entity.Property(e => e.SubaspekName)
                .HasColumnType("character varying")
                .HasColumnName("subaspek_name");
            entity.Property(e => e.SubaspekTarget).HasColumnName("subaspek_target");

            entity.HasOne(d => d.Aspek).WithMany(p => p.Subaspeks)
                .HasForeignKey(d => d.AspekId)
                .HasConstraintName("subaspek_aspek_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Username)
                .HasColumnType("character varying")
                .HasColumnName("username");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Role)
                .HasConstraintName("users_role_fkey");
        });

        modelBuilder.Entity<Workmainindicator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("workmainindicator_pkey");

            entity.ToTable("workmainindicator");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Aktual).HasColumnName("aktual");
            entity.Property(e => e.AnuallycompetencesId).HasColumnName("anuallycompetences_id");
            entity.Property(e => e.Bobot).HasColumnName("bobot");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Kpi)
                .HasColumnType("character varying")
                .HasColumnName("kpi");
            entity.Property(e => e.NilaiUnjukKerja).HasColumnName("nilai_unjuk_kerja");
            entity.Property(e => e.Period).HasColumnName("period");
            entity.Property(e => e.Polarisasi)
                .HasColumnType("character varying")
                .HasColumnName("polarisasi");
            entity.Property(e => e.StrategicObjective)
                .HasColumnType("character varying")
                .HasColumnName("strategic_objective");
            entity.Property(e => e.Target).HasColumnName("target");
            entity.Property(e => e.TingkatUnjukKerja).HasColumnName("tingkat_unjuk_kerja");
            entity.Property(e => e.UnitOfMeasurement)
                .HasColumnType("character varying")
                .HasColumnName("unit_of_measurement");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Anuallycompetences).WithMany(p => p.Workmainindicators)
                .HasForeignKey(d => d.AnuallycompetencesId)
                .HasConstraintName("workmainindicator_anuallycompetences_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Workmainindicators)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("workmainindicator_user_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
