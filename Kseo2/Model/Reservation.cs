namespace Kseo2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reservation.Reservation")]
    public class Reservation :Entity,IEntity
    {
        public Reservation()
        {
            Creator = Environment.UserName;
            Prolongations = new HashSet<Prolongation>();
        }

        public int Id { get; set; }
        
        [Required]
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        [Column(TypeName = "ntext")]
        public string Notes { get; set; }
        
        [Required]
        public DateTime CreationTime { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Creator { get; set; }
        public DateTime TerminationTime { get; set; }
        [MaxLength(50)]
        public string TerminationRegistrant { get; set; }
        
        [Required]
        public Person ReservedPerson { get; set; }

        public virtual OrganizationalUnit ConductingUnit { get; set; }
        public virtual ICollection<Prolongation> Prolongations { get; set; }
        public virtual ReservationPurpose Purpose { get; set; }
        public virtual ReservationEndReason EndReason { get; set; }

        public EntityState EntityState { get; set; }
    }
}
