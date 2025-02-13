using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Absence> Absences { get; set; }

    public virtual DbSet<Calendar> Calendars { get; set; }

    public virtual DbSet<CalendarType> CalendarTypes { get; set; }

    public virtual DbSet<Canditate> Canditates { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventStatus> EventStatuses { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<MaterialStatus> MaterialStatuses { get; set; }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<TrainingClass> TrainingClasses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WorkingCalendar> WorkingCalendars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-QR6M5JQ;Database=db13022025;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Absence>(entity =>
        {
            entity.HasOne(d => d.Employee).WithMany(p => p.AbsenceEmployees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Absences_Employees");

            entity.HasOne(d => d.Substitutel).WithMany(p => p.AbsenceSubstitutels)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Absences_Employees1");
        });

        modelBuilder.Entity<Calendar>(entity =>
        {
            entity.HasOne(d => d.CalendarType).WithMany(p => p.Calendars)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calendars_CalendarTypes");

            entity.HasOne(d => d.Department).WithMany(p => p.Calendars)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calendars_Departments");

            entity.HasOne(d => d.Employee).WithMany(p => p.Calendars)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calendars_Employees");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasOne(d => d.Author).WithMany(p => p.Comments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Employees");

            entity.HasOne(d => d.Document).WithMany(p => p.Comments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Documents");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasOne(d => d.Manager).WithMany(p => p.Departments).HasConstraintName("FK_Departments_Employees");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employees_Departments");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employees_Positions");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasOne(d => d.Calendar).WithMany(p => p.Events)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Events_Calendars");

            entity.HasOne(d => d.EventStatus).WithMany(p => p.Events)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Events_EventStatuses");

            entity.HasOne(d => d.EventType).WithMany(p => p.Events)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Events_EventTypes");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasOne(d => d.MaterialStatus).WithMany(p => p.Materials)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Materials_MaterialStatuses");

            entity.HasOne(d => d.MaterialType).WithMany(p => p.Materials)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Materials_MaterialTypes");
        });

        modelBuilder.Entity<TrainingClass>(entity =>
        {
            entity.HasOne(d => d.Event).WithMany(p => p.TrainingClasses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TrainingClasses_Events");

            entity.HasOne(d => d.Material).WithMany(p => p.TrainingClasses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TrainingClasses_Materials");
        });

        modelBuilder.Entity<WorkingCalendar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("WorkingCalendar_pk");

            entity.ToTable("WorkingCalendar", tb => tb.HasComment("Список дней исключений в производственном календаре"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasComment("Идентификатор строки");
            entity.Property(e => e.ExceptionDate).HasComment("День-исключение");
            entity.Property(e => e.IsWorkingDay).HasComment("0 - будний день, но законодательно принят выходным");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
