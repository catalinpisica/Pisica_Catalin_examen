namespace BazaDateModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BazaDateEntitiesModel : DbContext
    {
        public BazaDateEntitiesModel()
            : base("name=BazaDateEntitiesModel")
        {
        }

        public virtual DbSet<Angajati> Angajati { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Angajati>()
                .Property(e => e.Nume)
                .IsFixedLength();

            modelBuilder.Entity<Angajati>()
                .Property(e => e.Prenume)
                .IsFixedLength();

            modelBuilder.Entity<Angajati>()
                .Property(e => e.Functia)
                .IsFixedLength();

            modelBuilder.Entity<Angajati>()
                .Property(e => e.Varsta)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Angajati>()
                .Property(e => e.Salariu_brut_RON)
                .HasPrecision(18, 0);
        }
    }
}
