namespace Kseo2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reservation.Prolongation")]
    public class Prolongation :Entity,IEntity
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        
        public DateTime CreationTime { get; set; }
        
        public virtual Employee Employee { get; set; }

        public virtual OrganizationalUnit OrganizationalUnit { get; set; }

        public EntityState EntityState { get; set; }
        
    }
}
