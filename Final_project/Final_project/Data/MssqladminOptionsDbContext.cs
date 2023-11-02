using System;
using System.Collections.Generic;
using Final_project.Models.AdminOptions;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Data;

public partial class MssqladminOptionsDbContext : DbContext
{
    public MssqladminOptionsDbContext()
    {
    }

    public MssqladminOptionsDbContext(DbContextOptions<MssqladminOptionsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BlogSection> BlogSections { get; set; }

    public virtual DbSet<ContactSection> ContactSections { get; set; }

    public virtual DbSet<FooterSection> FooterSections { get; set; }

    public virtual DbSet<HeaderSection> HeaderSections { get; set; }

    public virtual DbSet<ProjectsSection> ProjectsSections { get; set; }

    public virtual DbSet<ServicesSection> ServicesSections { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MSSQLAdminOptionsDB;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BlogSection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BlogSect__3213E83FBC314320");

            entity.ToTable("BlogSection");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Date)
                .HasMaxLength(20)
                .HasColumnName("date");
            entity.Property(e => e.Photo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("photo");
            entity.Property(e => e.Text)
                .HasColumnType("text")
                .HasColumnName("text");
        });

        modelBuilder.Entity<ContactSection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ContactS__3213E83F3821F8F0");

            entity.ToTable("ContactSection");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Text)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("text");
        });

        modelBuilder.Entity<FooterSection>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("FooterSection");

            entity.Property(e => e.ContactsId).HasColumnName("contactsId");
            entity.Property(e => e.ContactsPath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contactsPath");
            entity.Property(e => e.LocationPhoto)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("locationPhoto");
            entity.Property(e => e.TextAbout)
                .HasColumnType("text")
                .HasColumnName("textAbout");
        });

        modelBuilder.Entity<HeaderSection>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("HeaderSection");

            entity.Property(e => e.Header).HasMaxLength(30);
            entity.Property(e => e.MainInfo).HasMaxLength(30);
        });

        modelBuilder.Entity<ProjectsSection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Projects__3213E83F80FFA181");

            entity.ToTable("ProjectsSection");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Header)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("header");
            entity.Property(e => e.Photo)
                .HasMaxLength(30)
                .HasColumnName("photo");
            entity.Property(e => e.Text)
                .HasColumnType("text")
                .HasColumnName("text");
        });

        modelBuilder.Entity<ServicesSection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Services__3213E83FF5D9647E");

            entity.ToTable("ServicesSection");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.HeaderOfService).HasMaxLength(30);
            entity.Property(e => e.Text)
                .HasColumnType("text")
                .HasColumnName("text");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
