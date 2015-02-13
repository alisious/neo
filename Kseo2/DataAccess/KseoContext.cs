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
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<KseoContext>(new KseoContextInitializer());
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AddressType> AddressTypes { get; set; }
        public virtual DbSet<Workplace> Workplaces { get; set; }
        public virtual DbSet<Rank> Ranks { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<OrganizationalUnit> OrganizationalUnits { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionForm> QuestionForms { get; set; }
        public virtual DbSet<QuestionReason> QuestionReasons { get; set; }
        public virtual DbSet<Verification> Verifications { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOptional(e => e.Nationality);
                       
            modelBuilder.Entity<Person>()
                .HasMany(e=>e.Citizenships)
                .WithMany()
                .Map(m => m.ToTable("Citizenship", "Person"));

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Workplaces);
            
            modelBuilder.Entity<Person>()
                .HasMany(e => e.Addresses);

            modelBuilder.Entity<Address>()
                .HasRequired(e => e.AddressType);
            
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

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.Subitems)
                .WithOptional(x => x.Masteritem);

            modelBuilder.Entity<OrganizationalUnit>()
                .HasMany(e => e.Subordinates)
                .WithOptional(x => x.MasterUnit); 

            modelBuilder.Entity<Verification>()
                .HasRequired(e => e.QuestionReason);

            modelBuilder.Entity<Verification>()
                .HasRequired(e => e.Author);

            modelBuilder.Entity<Verification>()
                .HasOptional(e => e.FoundedPerson);

            modelBuilder.Entity<Verification>()
                .HasOptional(e => e.Nationality);

            modelBuilder.Entity<Verification>()
                .HasRequired(e => e.Question)
                .WithMany(q => q.Verifications);

            modelBuilder.Entity<Verification>()
                .HasMany(e => e.Citizenships)
                .WithMany()
                .Map(m => m.ToTable("Citizenship", "Verification"));


            /*
            modelBuilder.Entity<Question>()
                .HasMany(e => e.Verification)
                .WithRequired(e => e.Question)
                .WillCascadeOnDelete(false);
            */


            //modelBuilder.Entity<Person>()
            //    .HasMany<Verification>(p => p.Verifications)
            //    .WithRequired(v => v.Person);

        }
    }
}
