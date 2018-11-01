namespace Blog.UI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DufyContext : DbContext
    {
        public DufyContext()
            : base("name=DufyContext")
        {
        }

        public virtual DbSet<Etiket> Etiket { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<Makale> Makale { get; set; }
        public virtual DbSet<Yetki> Yetki { get; set; }
        public virtual DbSet<Yorum> Yorum { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Etiket>()
                .HasMany(e => e.Makale)
                .WithMany(e => e.Etiket)
                .Map(m => m.ToTable("MakaleEtiket").MapLeftKey("EtiketID").MapRightKey("MakaleID"));

            modelBuilder.Entity<Kategori>()
                .HasMany(e => e.Makale)
                .WithRequired(e => e.Kategori)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.Makale)
                .WithRequired(e => e.Kullanici)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.Yorum)
                .WithRequired(e => e.Kullanici)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Makale>()
                .HasMany(e => e.Yorum)
                .WithRequired(e => e.Makale)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Yetki>()
                .HasMany(e => e.Kullanici)
                .WithRequired(e => e.Yetki)
                .WillCascadeOnDelete(false);
        }
    }
}
