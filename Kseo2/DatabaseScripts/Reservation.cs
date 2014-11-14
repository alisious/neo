namespace Kseo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reservation.Reservation")]
    public partial class Reservation
    {
        public Reservation()
        {
            Prolongation = new HashSet<Prolongation>();
        }

        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TerminationDate { get; set; }

        [Column(TypeName = "ntext")]
        public string Notes { get; set; }

        public int? Person_Id { get; set; }

        public int ConductingOfficer_Id { get; set; }

        public int? ConductingUnit_Id { get; set; }

        public int ReservationPurpose_Id { get; set; }

        public int? EndReason_Id { get; set; }

        public int? Terminator_Id { get; set; }

        public DateTime CreationTime { get; set; }

        public int Creator_Id { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Operator Operator { get; set; }

        public virtual Operator Operator1 { get; set; }

        public virtual Operator Operator2 { get; set; }

        public virtual OrganizationalUnit OrganizationalUnit { get; set; }

        public virtual ICollection<Prolongation> Prolongation { get; set; }

        public virtual Purpose Purpose { get; set; }

        public virtual ReservationEndReason ReservationEndReason { get; set; }
    }
}
