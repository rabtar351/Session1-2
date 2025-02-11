using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models.Entities;

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

    public virtual DbSet<DeparmtentPosition> DeparmtentPositions { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventEmployee> EventEmployees { get; set; }

    public virtual DbSet<EventEmployeeType> EventEmployeeTypes { get; set; }

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
        => optionsBuilder.UseSqlServer("Server=DESKTOP-QR6M5JQ;Database=dbSession1_GasaevIslam;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Absence>(entity =>
        {
            entity.Property(e => e.AbsencesId).ValueGeneratedNever();

            entity.HasOne(d => d.Employee).WithMany(p => p.AbsenceEmployees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Absences_Employees");

            entity.HasOne(d => d.Sustitutel).WithMany(p => p.AbsenceSustitutels)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Absences_Employees1");
        });

        modelBuilder.Entity<Calendar>(entity =>
        {
            entity.Property(e => e.CalendarId).ValueGeneratedNever();

            entity.HasOne(d => d.CalendarType).WithMany(p => p.Calendars)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calendars_CalendarTypes");

            entity.HasOne(d => d.Department).WithMany(p => p.Calendars).HasConstraintName("FK_Calendars_Departments");

            entity.HasOne(d => d.Employee).WithMany(p => p.Calendars).HasConstraintName("FK_Calendars_Employees");
        });

        modelBuilder.Entity<CalendarType>(entity =>
        {
            entity.Property(e => e.CalendarTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Canditate>(entity =>
        {
            entity.Property(e => e.CanditateId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Author).WithMany(p => p.Comments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Employees");

            entity.HasOne(d => d.Document).WithMany(p => p.Comments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Documents");
        });

        modelBuilder.Entity<DeparmtentPosition>(entity =>
        {
            entity.HasOne(d => d.Department).WithMany(p => p.DeparmtentPositions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DeparmtentPositions_Departments");

            entity.HasOne(d => d.Position).WithMany(p => p.DeparmtentPositions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DeparmtentPositions_Positions");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.Property(e => e.DepartmentId).ValueGeneratedNever();

            entity.HasOne(d => d.Manager).WithMany(p => p.Departments).HasConstraintName("FK_Departments_Employees");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.EmployeeId).ValueGeneratedNever();

            entity.HasOne(d => d.Department).WithMany(p => p.Employees).HasConstraintName("FK_Employees_Departments");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees).HasConstraintName("FK_Employees_Positions");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.Property(e => e.EventId).ValueGeneratedNever();

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

        modelBuilder.Entity<EventEmployee>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Employee).WithMany(p => p.EventEmployees).HasConstraintName("FK_EventEmployees_Employees");

            entity.HasOne(d => d.EventEmployeeType).WithMany(p => p.EventEmployees).HasConstraintName("FK_EventEmployees_EventEmployeeTypes");
        });

        modelBuilder.Entity<EventEmployeeType>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<EventStatus>(entity =>
        {
            entity.Property(e => e.EventStatusId).ValueGeneratedNever();
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.Property(e => e.EventTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.Property(e => e.MaterialId).ValueGeneratedNever();

            entity.HasOne(d => d.MaterialStatus).WithMany(p => p.Materials)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Materials_MaterialStatuses");

            entity.HasOne(d => d.MaterialType).WithMany(p => p.Materials)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Materials_MaterialTypes");
        });

        modelBuilder.Entity<MaterialStatus>(entity =>
        {
            entity.Property(e => e.MaterialStatusId).ValueGeneratedNever();
        });

        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.Property(e => e.MaterialTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.Property(e => e.PositionId).ValueGeneratedNever();
        });

        modelBuilder.Entity<TrainingClass>(entity =>
        {
            entity.Property(e => e.TrainingId).ValueGeneratedNever();

            entity.HasOne(d => d.Event).WithMany(p => p.TrainingClasses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TrainingClasses_Events");

            entity.HasOne(d => d.Material).WithMany(p => p.TrainingClasses).HasConstraintName("FK_TrainingClasses_Materials");
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
