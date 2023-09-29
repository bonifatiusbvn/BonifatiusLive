using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EMPManagment.API;

public partial class BonifatiusEmployeesContext : DbContext
{
    public BonifatiusEmployeesContext()
    {
    }

    public BonifatiusEmployeesContext(DbContextOptions<BonifatiusEmployeesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAttendance> TblAttendances { get; set; }

    public virtual DbSet<TblCity> TblCities { get; set; }

    public virtual DbSet<TblCountry> TblCountries { get; set; }

    public virtual DbSet<TblDepartment> TblDepartments { get; set; }

    public virtual DbSet<TblQuestion> TblQuestions { get; set; }

    public virtual DbSet<TblState> TblStates { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=BONI002\\SQLEXPRESS;Database=BonifatiusEmployees;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAttendance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tbl_BoniAttendance");

            entity.ToTable("tblAttendance");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Intime)
                .HasColumnType("datetime")
                .HasColumnName("INTime");
            entity.Property(e => e.OutTime).HasColumnType("datetime");
            entity.Property(e => e.TotalHours).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblAttendances)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_BoniAttendance_tbl_BoniUsers");
        });

        modelBuilder.Entity<TblCity>(entity =>
        {
            entity.ToTable("tblCity");

            entity.Property(e => e.City).HasMaxLength(50);

            entity.HasOne(d => d.State).WithMany(p => p.TblCities)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblCity_tblState");
        });

        modelBuilder.Entity<TblCountry>(entity =>
        {
            entity.ToTable("tblCountry");

            entity.Property(e => e.Country).HasMaxLength(30);
        });

        modelBuilder.Entity<TblDepartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tbl_BoniDepartment");

            entity.ToTable("tblDepartment");

            entity.Property(e => e.CreatedBy).HasMaxLength(20);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Department).HasMaxLength(50);
        });

        modelBuilder.Entity<TblQuestion>(entity =>
        {
            entity.ToTable("tblQuestion");
        });

        modelBuilder.Entity<TblState>(entity =>
        {
            entity.ToTable("tblState");

            entity.Property(e => e.State).HasMaxLength(50);

            entity.HasOne(d => d.Country).WithMany(p => p.TblStates)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblState_tblCountry1");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tlb_BoniUsers");

            entity.ToTable("tblUsers");

            entity.Property(e => e.Address).HasMaxLength(80);
            entity.Property(e => e.Answer).HasMaxLength(50);
            entity.Property(e => e.CreatedBy).HasMaxLength(20);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.EmpId).HasMaxLength(20);
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.Gender).HasMaxLength(8);
            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
            entity.Property(e => e.LastName).HasMaxLength(30);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.Pincode).HasMaxLength(20);

            entity.HasOne(d => d.City).WithMany(p => p.TblUsers)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_tblUsers_tblCity");

            entity.HasOne(d => d.Country).WithMany(p => p.TblUsers)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_tblUsers_tblCountry");

            entity.HasOne(d => d.Department).WithMany(p => p.TblUsers)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_tbl_BoniUsers_tbl_Departmen");

            entity.HasOne(d => d.Question).WithMany(p => p.TblUsers)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK_tblUsers_tblQuestion");

            entity.HasOne(d => d.State).WithMany(p => p.TblUsers)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK_tblUsers_tblState");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
