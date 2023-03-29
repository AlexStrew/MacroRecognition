using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RecognitionAPI.Models;

public partial class RecognitionDbContext : DbContext
{
    public RecognitionDbContext()
    {
    }

    public RecognitionDbContext(DbContextOptions<RecognitionDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TruckDetection> TruckDetections { get; set; }
    public virtual DbSet<DamaskClass> DamaskClasse { get; set; }
    //public virtual DbSet<UsersClass> UsersClasses { get; set; }
    public DbSet<UsersClass> UsersClasses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=hv-sql;Database=RecognitionDB;Persist Security Info=False;user=api-user;Password=QFgQJkWi4t;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TruckDetection>(entity =>
        {
            entity.HasKey(e => e.IdReco);

            entity.ToTable("TruckDetection");

            entity.Property(e => e.IdReco).HasColumnName("id_reco");
            entity.Property(e => e.AdditionalInfo)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("additionalInfo");
            entity.Property(e => e.BinaryTimestamp)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Carbrand)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("carbrand");
            entity.Property(e => e.Carcolor)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("carcolor");
            entity.Property(e => e.ChannelId)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ChannelName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Comment)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Direction)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("direction");
            entity.Property(e => e.EventDescription)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.EventId)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.EventType)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ExternalId)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ExternalOwnerId)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.Groups)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("groups");
            entity.Property(e => e.Height)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.InitiatorName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.IsAlarmEvent)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.IsIdentified)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.Left)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Numberplate)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Patronymic)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("patronymic");
            entity.Property(e => e.PlateText)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("plateText");
            entity.Property(e => e.Reliability)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Speed)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Timestamp)
                .IsUnicode(false);
            entity.Property(e => e.Top)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Width)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ZonedTimestamp)
                .HasMaxLength(150)
                .IsUnicode(false);
        });
        modelBuilder.Entity<UsersClass>(entity =>
        {
            entity.HasKey(e => e.id);

            entity.ToTable("Users");

            entity.Property(e => e.id).HasColumnName("id");

            entity.Property(e => e.username)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.Property(e => e.password)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("password");

            OnModelCreatingPartial(modelBuilder);
        });
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
