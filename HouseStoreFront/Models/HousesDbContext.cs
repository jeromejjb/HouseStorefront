using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HouseStoreFront.Models
{
    public partial class HousesDbContext : DbContext
    {
        public HousesDbContext()
        {
        }

        public HousesDbContext(DbContextOptions<HousesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<House> Houses { get; set; }
        public virtual DbSet<StateEnum> StateEnums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\MSSQLSERVER01;Database=HousesDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<House>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(25);

                entity.Property(e => e.Description).HasMaxLength(1);

                entity.Property(e => e.State).HasMaxLength(2);

                entity.HasOne(d => d.StateNavigation)
                    .WithMany(p => p.Houses)
                    .HasForeignKey(d => d.State)
                    .HasConstraintName("FK__Houses__State__286302EC");
            });

            modelBuilder.Entity<StateEnum>(entity =>
            {
                entity.HasKey(e => e.State)
                    .HasName("PK__GenreEnu__BA803DACC2E38BF5");

                entity.ToTable("StateEnum");

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('MI')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
