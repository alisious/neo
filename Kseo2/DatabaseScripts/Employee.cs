namespace Kseo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Common.Employee")]
    public partial class Employee
    {
        public Employee()
        {
            Prolongation = new HashSet<Prolongation>();
            Reservation = new HashSet<Reservation>();
        }

        public int Id { get; set; }

        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public int? Rank_Id { get; set; }

        public int Organization_Id { get; set; }

        public int? OrganizationalUnit_Id { get; set; }

        public int? Position_Id { get; set; }

        public virtual OrganizationalUnit OrganizationalUnit { get; set; }

        public virtual ICollection<Prolongation> Prolongation { get; set; }

        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
