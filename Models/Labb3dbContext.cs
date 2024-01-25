using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Labb3db.Models
{
    public partial class Labb3dbContext : DbContext
    {
        public Labb3dbContext()
        {
        }

        public Labb3dbContext(DbContextOptions<Labb3dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anställdum> Anställda { get; set; } = null!;
        public virtual DbSet<Befattningar> Befattningars { get; set; } = null!;
        public virtual DbSet<Betyg> Betygs { get; set; } = null!;
        public virtual DbSet<Elever> Elevers { get; set; } = null!;
        public virtual DbSet<Klasser> Klassers { get; set; } = null!;
        public virtual DbSet<Kurser> Kursers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data source = DAGGESDUNDERPC;Initial Catalog = Håstensskolan;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anställdum>(entity =>
            {
                entity.HasKey(e => e.AnställningsId);

                entity.Property(e => e.AnställningsId).HasColumnName("AnställningsID");

                entity.Property(e => e.BefattningsId).HasColumnName("BefattningsID");

                entity.Property(e => e.Efternamn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Förnamn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Befattnings)
                    .WithMany(p => p.Anställda)
                    .HasForeignKey(d => d.BefattningsId)
                    .HasConstraintName("FK_Anställda_Befattningar");

                entity.HasMany(d => d.Klasses)
                    .WithMany(p => p.Lärares)
                    .UsingEntity<Dictionary<string, object>>(
                        "LärareKlass",
                        l => l.HasOne<Klasser>().WithMany().HasForeignKey("KlassId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__LärareKla__Klass__4D94879B"),
                        r => r.HasOne<Anställdum>().WithMany().HasForeignKey("LärareId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__LärareKla__Lärar__4CA06362"),
                        j =>
                        {
                            j.HasKey("LärareId", "KlassId").HasName("PK__LärareKl__35F402AD65499238");

                            j.ToTable("LärareKlass");

                            j.IndexerProperty<int>("LärareId").HasColumnName("LärareID");

                            j.IndexerProperty<int>("KlassId").HasColumnName("KlassID");
                        });

                entity.HasMany(d => d.Kurs)
                    .WithMany(p => p.Lärares)
                    .UsingEntity<Dictionary<string, object>>(
                        "LärareKur",
                        l => l.HasOne<Kurser>().WithMany().HasForeignKey("KursId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__LärareKur__KursI__5165187F"),
                        r => r.HasOne<Anställdum>().WithMany().HasForeignKey("LärareId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__LärareKur__Lärar__5070F446"),
                        j =>
                        {
                            j.HasKey("LärareId", "KursId").HasName("PK__LärareKu__52CC873EC8CB2BB9");

                            j.ToTable("LärareKurs");

                            j.IndexerProperty<int>("LärareId").HasColumnName("LärareID");

                            j.IndexerProperty<int>("KursId").HasColumnName("KursID");
                        });
            });

            modelBuilder.Entity<Befattningar>(entity =>
            {
                entity.HasKey(e => e.BefattningsId);

                entity.ToTable("Befattningar");

                entity.Property(e => e.BefattningsId).HasColumnName("BefattningsID");

                entity.Property(e => e.Befattninsnamn)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Betyg>(entity =>
            {
                entity.HasKey(e => e.BetygsId)
                    .HasName("PK__Betyg__2DD1328F4623B297");

                entity.ToTable("Betyg");

                entity.Property(e => e.BetygsId).HasColumnName("BetygsID");

                entity.Property(e => e.AnställningsId).HasColumnName("AnställningsID");

                entity.Property(e => e.Betyg1)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("Betyg");

                entity.Property(e => e.DatumSatt).HasColumnType("datetime");

                entity.Property(e => e.ElevId).HasColumnName("ElevID");

                entity.Property(e => e.KursId).HasColumnName("KursID");

                entity.HasOne(d => d.Anställnings)
                    .WithMany(p => p.Betygs)
                    .HasForeignKey(d => d.AnställningsId)
                    .HasConstraintName("FK_Anställda");

                entity.HasOne(d => d.Elev)
                    .WithMany(p => p.Betygs)
                    .HasForeignKey(d => d.ElevId)
                    .HasConstraintName("FK_Elev");

                entity.HasOne(d => d.Kurs)
                    .WithMany(p => p.Betygs)
                    .HasForeignKey(d => d.KursId)
                    .HasConstraintName("FK_Kurs");
            });

            modelBuilder.Entity<Elever>(entity =>
            {
                entity.HasKey(e => e.ElevId);

                entity.ToTable("Elever");

                entity.Property(e => e.ElevId).HasColumnName("ElevID");

                entity.Property(e => e.Efternamn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Förnamn)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KlassId).HasColumnName("KlassID");

                entity.Property(e => e.Personnummer).HasColumnType("date");

                entity.HasOne(d => d.Klass)
                    .WithMany(p => p.Elevers)
                    .HasForeignKey(d => d.KlassId)
                    .HasConstraintName("FK_Elever_Klasser");
            });

            modelBuilder.Entity<Klasser>(entity =>
            {
                entity.HasKey(e => e.KlassId)
                    .HasName("PK__Klasser__CF47A60D541FE612");

                entity.ToTable("Klasser");

                entity.Property(e => e.KlassId)
                    .ValueGeneratedNever()
                    .HasColumnName("KlassID");

                entity.Property(e => e.Klassnamn)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kurser>(entity =>
            {
                entity.HasKey(e => e.KursId)
                    .HasName("PK__Kurser__BCCFFF3B46A8CA11");

                entity.ToTable("Kurser");

                entity.Property(e => e.KursId)
                    .ValueGeneratedNever()
                    .HasColumnName("KursID");

                entity.Property(e => e.Kurstitel)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
