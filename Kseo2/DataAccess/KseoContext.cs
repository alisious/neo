namespace Kseo2.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Kseo2.Model;

    public partial class KseoContext : DbContext
    {
        public KseoContext()
            : base("name=KseoContext")
        {
            Database.SetInitializer<KseoContext>(new KseoContextInitializer());
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        //public virtual DbSet<Verification> Verifications { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOptional(e => e.Nationality)
                .WithMany();
                
            
            modelBuilder.Entity<Person>()
                .HasMany(e=>e.Citizenships)
                .WithMany()
                .Map(m => m.ToTable("Citizenship", "Person"));

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Subitems)
                .WithOptional(x => x.Masteritem);

            modelBuilder.Entity<Rank>()
                  .HasMany(e => e.Subitems)
                  .WithOptional(x => x.Masteritem);

            modelBuilder.Entity<QuestionForm>()
                .HasMany(e => e.Subitems)
                .WithOptional(x => x.Masteritem);

            modelBuilder.Entity<QuestionReason>()
                .HasMany(e => e.Subitems)
                .WithOptional(x => x.Masteritem);

            //modelBuilder.Entity<Person>()
            //    .HasMany<Verification>(p => p.Verifications)
            //    .WithRequired(v => v.Person);
            
        }
    }
}
