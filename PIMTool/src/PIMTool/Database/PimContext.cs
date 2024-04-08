using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace PIMTool.Database;

public partial class PimContext : DbContext
{
    public PimContext()
    {
    }

    public PimContext(DbContextOptions<PimContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectEmployee> ProjectEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(GetConnectionString());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("Employee_pkey");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("EmployeeID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Visa).HasMaxLength(1);
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Group_pkey");

            entity.ToTable("Group");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            entity.HasOne(d => d.GroupLeaderNavigation).WithMany(p => p.Groups)
                .HasForeignKey(d => d.GroupLeader)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Group_GroupLeader_fkey");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Project_pkey");

            entity.ToTable("Project");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.Customer)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.Name).HasMaxLength(1);

            entity.HasOne(d => d.Group).WithMany(p => p.Projects)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Project_GroupID_fkey");
        });

        modelBuilder.Entity<ProjectEmployee>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Project_Employee");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.ProjectId)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("ProjectID");

            entity.HasOne(d => d.Employee).WithMany()
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Project_Employee_EmployeeID_fkey");

            entity.HasOne(d => d.Project).WithMany()
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Project_Employee_ProjectID_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    private string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();
        var strConn = config["ConnectionStrings:DefaultConnection"];

        return strConn;
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
