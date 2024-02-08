using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SevenMinutesBook_V1.Server.Ef_models
{
    public partial class SevenMinBooksContext : DbContext
    {
        public SevenMinBooksContext()
        {
        }

        public SevenMinBooksContext(DbContextOptions<SevenMinBooksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Continent> Continents { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Description> Descriptions { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<LoginUserDetail> LoginUserDetails { get; set; } = null!;
        public virtual DbSet<Publisher> Publishers { get; set; } = null!;
        public virtual DbSet<SubGenre> SubGenres { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=SevenMinBooks;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author");

                entity.HasIndex(e => e.BirthCountry, "IX_Author_BirthCountry");

                entity.HasIndex(e => e.ContinentId, "IX_Author_ContinentId");

                entity.HasOne(d => d.BirthCountryNavigation)
                    .WithMany(p => p.Authors)
                    .HasForeignKey(d => d.BirthCountry)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Continent)
                    .WithMany(p => p.Authors)
                    .HasForeignKey(d => d.ContinentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.HasIndex(e => e.AuthorId, "IX_Book_AuthorId");

                entity.HasIndex(e => e.GenreId, "IX_Book_GenreId");

                entity.HasIndex(e => e.PublisherId, "IX_Book_PublisherId");

                entity.HasIndex(e => e.SubGenreId, "IX_Book_SubGenreId");

                entity.Property(e => e.About).HasMaxLength(1500);

                entity.Property(e => e.BookTitle).HasColumnName("Book Title");

                entity.Property(e => e.Isbn).HasColumnName("ISBN");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.PublisherId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.SubGenre)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.SubGenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Continent>(entity =>
            {
                entity.HasKey(e => e.ContientId)
                    .HasName("ContinentId");

                entity.ToTable("Continent");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.HasIndex(e => e.ContinentId, "IX_Country_ContinentId");

                entity.HasOne(d => d.Continent)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.ContinentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Description>(entity =>
            {
                entity.ToTable("Description");

                entity.Property(e => e.Id)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.About)
                    .HasMaxLength(3000)
                    .IsUnicode(false)
                    .HasColumnName("about");

                entity.Property(e => e.AuthorId).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.BookId).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IsDeactivated)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.ModificationDt).HasColumnName("Modification_DT");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");
            });

            modelBuilder.Entity<LoginUserDetail>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__loginUse__CB9A1CFF4528FE24");

                entity.ToTable("loginUserDetails");

                entity.HasIndex(e => e.Email, "UQ__loginUse__AB6E616416E17A05")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("userId");

                entity.Property(e => e.DeactivatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.EntryOn).HasColumnType("datetime");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsAdmin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsDeactivate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Token)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.ToTable("Publisher");

                entity.HasIndex(e => e.ContinetId, "IX_Publisher_ContinetId");

                entity.HasIndex(e => e.CountryId, "IX_Publisher_CountryId");

                entity.HasOne(d => d.Continet)
                    .WithMany(p => p.Publishers)
                    .HasForeignKey(d => d.ContinetId);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Publishers)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<SubGenre>(entity =>
            {
                entity.ToTable("SubGenre");

                entity.HasIndex(e => e.GenreId, "IX_SubGenre_GenreId");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.SubGenres)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
