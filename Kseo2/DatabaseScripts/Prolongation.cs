namespace Kseo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reservation.Prolongation")]
    public partial class Prolongation
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        public int ConductingOfficer_Id { get; set; }

        public int ConductingUnit_Id { get; set; }

        public int Reservation_Id { get; set; }

        public DateTime CreationTime { get; set; }

        public int Creator_Id { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual OrganizationalUnit OrganizationalUnit { get; set; }

        public virtual Reservation Reservation { get; set; }
    }
}
