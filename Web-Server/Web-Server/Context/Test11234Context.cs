using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Web_Server.Models;

namespace Web_Server.Context;

public partial class Test11234Context : DbContext
{
    public Test11234Context()
    {
    }

    public Test11234Context(DbContextOptions<Test11234Context> options)
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

    public virtual DbSet<TrainingClasses12> TrainingClasses12s { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-QR6M5JQ;Database=Test11234;Trusted_Connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Absence>(entity =>
        {
            entity.Property(e => e.AbsenceId).HasColumnName("AbsenceID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.SubstituteId).HasColumnName("SubstituteID");

            entity.HasOne(d => d.Employee).WithMany(p => p.Absences)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Absences_Employees");
        });

        modelBuilder.Entity<Calendar>(entity =>
        {
            entity.Property(e => e.CalendarId).HasColumnName("CalendarID");
            entity.Property(e => e.CalendarTypeId).HasColumnName("CalendarTypeID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

            entity.HasOne(d => d.CalendarType).WithMany(p => p.Calendars)
                .HasForeignKey(d => d.CalendarTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calendars_CalendarTypes");

            entity.HasOne(d => d.Department).WithMany(p => p.Calendars)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calendars_Departments");

            entity.HasOne(d => d.Employee).WithMany(p => p.Calendars)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calendars_Employees");
        });

        modelBuilder.Entity<CalendarType>(entity =>
        {
            entity.Property(e => e.CalendarTypeId).HasColumnName("CalendarTypeID");
            entity.Property(e => e.CalendarTypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Canditate>(entity =>
        {
            entity.HasKey(e => e.Candidate);

            entity.Property(e => e.Field).HasMaxLength(100);
            entity.Property(e => e.FirtsName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Resume).HasMaxLength(100);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("Date_created");
            entity.Property(e => e.DateUpdated)
                .HasColumnType("datetime")
                .HasColumnName("Date_updated");
            entity.Property(e => e.DocumentId).HasColumnName("Document_id");
            entity.Property(e => e.Position).HasMaxLength(50);
            entity.Property(e => e.Text).HasMaxLength(100);

            entity.HasOne(d => d.Author).WithMany(p => p.Comments)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Employees");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Comment)
                .HasForeignKey<Comment>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Documents");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName).HasMaxLength(100);
            entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

            entity.HasOne(d => d.Manager).WithMany(p => p.Departments)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK_Departments_Employees");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Category).HasMaxLength(100);
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("Date_created");
            entity.Property(e => e.DateUpdated)
                .HasColumnType("datetime")
                .HasColumnName("Date_updated");
            entity.Property(e => e.HasComments).HasColumnName("Has_comments");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.AssistantId).HasColumnName("AssistantID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MobilePhone).HasMaxLength(20);
            entity.Property(e => e.Office).HasMaxLength(10);
            entity.Property(e => e.PositionId).HasColumnName("PositionID");
            entity.Property(e => e.SupervisorId).HasColumnName("SupervisorID");
            entity.Property(e => e.WorkPhone).HasMaxLength(20);

            entity.HasOne(d => d.Assistant).WithMany(p => p.InverseAssistant)
                .HasForeignKey(d => d.AssistantId)
                .HasConstraintName("FK_Employees_Employees1");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_Employees_Departments");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK_Employees_Positions");

            entity.HasOne(d => d.Supervisor).WithMany(p => p.InverseSupervisor)
                .HasForeignKey(d => d.SupervisorId)
                .HasConstraintName("FK_Employees_Employees");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.CalendarId).HasColumnName("CalendarID");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.EventName).HasMaxLength(100);
            entity.Property(e => e.EventStatusId).HasColumnName("EventStatusID");
            entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Calendar).WithMany(p => p.Events)
                .HasForeignKey(d => d.CalendarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Events_Calendars");

            entity.HasOne(d => d.EventStatus).WithMany(p => p.Events)
                .HasForeignKey(d => d.EventStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Events_EventStatuses");

            entity.HasOne(d => d.EventType).WithMany(p => p.Events)
                .HasForeignKey(d => d.EventTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Events_EventTypes");
        });

        modelBuilder.Entity<EventStatus>(entity =>
        {
            entity.Property(e => e.EventStatusId).HasColumnName("EventStatusID");
            entity.Property(e => e.EventStatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");
            entity.Property(e => e.EventTypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.Property(e => e.MaterialId).HasColumnName("MaterialID");
            entity.Property(e => e.Author).HasMaxLength(100);
            entity.Property(e => e.Domain).HasMaxLength(100);
            entity.Property(e => e.MaterialName).HasMaxLength(100);
            entity.Property(e => e.MaterialStatusId).HasColumnName("MaterialStatusID");
            entity.Property(e => e.MaterialTypeId).HasColumnName("MaterialTypeID");

            entity.HasOne(d => d.MaterialStatus).WithMany(p => p.Materials)
                .HasForeignKey(d => d.MaterialStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Materials_MaterialStatuses");

            entity.HasOne(d => d.MaterialType).WithMany(p => p.Materials)
                .HasForeignKey(d => d.MaterialTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Materials_MaterialTypes");
        });

        modelBuilder.Entity<MaterialStatus>(entity =>
        {
            entity.Property(e => e.MaterialStatusId).HasColumnName("MaterialStatusID");
            entity.Property(e => e.MaterialStatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.Property(e => e.MaterialTypeId).HasColumnName("MaterialTypeID");
            entity.Property(e => e.MaterialTypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.Property(e => e.PositionId).HasColumnName("PositionID");
            entity.Property(e => e.PositionName).HasMaxLength(100);
        });

        modelBuilder.Entity<TrainingClasses12>(entity =>
        {
            entity.HasKey(e => e.TrainingId);

            entity.ToTable("TrainingClasses12");

            entity.Property(e => e.TrainingId).HasColumnName("TrainingID");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.MaterialId).HasColumnName("MaterialID");

            entity.HasOne(d => d.Event).WithMany(p => p.TrainingClasses12s)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TrainingClasses12_Events");

            entity.HasOne(d => d.Material).WithMany(p => p.TrainingClasses12s)
                .HasForeignKey(d => d.MaterialId)
                .HasConstraintName("FK_TrainingClasses12_Materials");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Name);

            entity.ToTable("User");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
