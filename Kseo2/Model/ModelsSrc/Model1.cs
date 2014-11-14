namespace Kseo2
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Kseo2.Models;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Operator> Operator { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<OrganizationalUnit> OrganizationalUnit { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Rank> Rank { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<ConductingOfficer> ConductingOfficer { get; set; }
        public virtual DbSet<ConductingUnit> ConductingUnit { get; set; }
        public virtual DbSet<Cooperation> Cooperation { get; set; }
        public virtual DbSet<CooperationEndReason> CooperationEndReason { get; set; }
        public virtual DbSet<Interaction> Interaction { get; set; }
        public virtual DbSet<ObtainingBase> ObtainingBase { get; set; }
        public virtual DbSet<PersonAlias> PersonAlias { get; set; }
        public virtual DbSet<Suspension> Suspension { get; set; }
        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<ActivityType> ActivityType { get; set; }
        public virtual DbSet<InvolvedPerson> InvolvedPerson { get; set; }
        public virtual DbSet<InvolveType> InvolveType { get; set; }
        public virtual DbSet<Issue> Issue { get; set; }
        public virtual DbSet<IssueCharakteristic> IssueCharakteristic { get; set; }
        public virtual DbSet<IssueType> IssueType { get; set; }
        public virtual DbSet<Prolongation> Prolongation { get; set; }
        public virtual DbSet<Purpose> Purpose { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<ReservationEndReason> ReservationEndReason { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<QuestionForm> QuestionForm { get; set; }
        public virtual DbSet<QuestionReason> QuestionReason { get; set; }
        public virtual DbSet<Verification> Verification { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Prolongation)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.ConductingOfficer_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Reservation)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.ConductingOfficer_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Operator>()
                .HasMany(e => e.Reservation)
                .WithOptional(e => e.Operator)
                .HasForeignKey(e => e.Terminator_Id);

            modelBuilder.Entity<Operator>()
                .HasMany(e => e.Reservation1)
                .WithRequired(e => e.Operator1)
                .HasForeignKey(e => e.Creator_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Operator>()
                .HasMany(e => e.Reservation2)
                .WithOptional(e => e.Operator2)
                .HasForeignKey(e => e.Terminator_Id);

            modelBuilder.Entity<Operator>()
                .HasMany(e => e.Verification)
                .WithRequired(e => e.Operator)
                .HasForeignKey(e => e.Creator_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.OrganizationalUnit)
                .WithRequired(e => e.Organization)
                .HasForeignKey(e => e.Organization_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.Question)
                .WithRequired(e => e.Organization)
                .HasForeignKey(e => e.AskerOrganization_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrganizationalUnit>()
                .HasMany(e => e.Employee)
                .WithOptional(e => e.OrganizationalUnit)
                .HasForeignKey(e => e.OrganizationalUnit_Id);

            modelBuilder.Entity<OrganizationalUnit>()
                .HasMany(e => e.Prolongation)
                .WithRequired(e => e.OrganizationalUnit)
                .HasForeignKey(e => e.ConductingUnit_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrganizationalUnit>()
                .HasMany(e => e.Question)
                .WithOptional(e => e.OrganizationalUnit)
                .HasForeignKey(e => e.AskerUnit_Id);

            modelBuilder.Entity<OrganizationalUnit>()
                .HasMany(e => e.Reservation)
                .WithOptional(e => e.OrganizationalUnit)
                .HasForeignKey(e => e.ConductingUnit_Id);

            modelBuilder.Entity<Position>()
                .HasMany(e => e.Operator)
                .WithOptional(e => e.Position)
                .HasForeignKey(e => e.Postion_Id);

            modelBuilder.Entity<Position>()
                .HasMany(e => e.Question)
                .WithOptional(e => e.Position)
                .HasForeignKey(e => e.SignerPosition_Id);

            modelBuilder.Entity<Rank>()
                .HasMany(e => e.Operator)
                .WithOptional(e => e.Rank)
                .HasForeignKey(e => e.Rank_Id);

            modelBuilder.Entity<Rank>()
                .HasMany(e => e.Question)
                .WithOptional(e => e.Rank)
                .HasForeignKey(e => e.AskerRank_Id);

            modelBuilder.Entity<Cooperation>()
                .Property(e => e.StartDate)
                .IsUnicode(false);

            modelBuilder.Entity<Cooperation>()
                .Property(e => e.EndDate)
                .IsUnicode(false);

            modelBuilder.Entity<Suspension>()
                .Property(e => e.StartDate)
                .IsUnicode(false);

            modelBuilder.Entity<Suspension>()
                .Property(e => e.EndDate)
                .IsUnicode(false);

            modelBuilder.Entity<Purpose>()
                .HasMany(e => e.Reservation)
                .WithRequired(e => e.Purpose)
                .HasForeignKey(e => e.ReservationPurpose_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reservation>()
                .HasMany(e => e.Prolongation)
                .WithRequired(e => e.Reservation)
                .HasForeignKey(e => e.Reservation_Id);

            modelBuilder.Entity<ReservationEndReason>()
                .HasMany(e => e.Reservation)
                .WithOptional(e => e.ReservationEndReason)
                .HasForeignKey(e => e.EndReason_Id);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Verification)
                .WithRequired(e => e.Question)
                .HasForeignKey(e => e.Question_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuestionForm>()
                .HasMany(e => e.Question)
                .WithRequired(e => e.QuestionForm)
                .HasForeignKey(e => e.Form_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuestionReason>()
                .HasMany(e => e.Question)
                .WithRequired(e => e.QuestionReason)
                .HasForeignKey(e => e.Reason_Id)
                .WillCascadeOnDelete(false);
        }
    }
}
