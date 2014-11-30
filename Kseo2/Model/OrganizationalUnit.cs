namespace Kseo2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Common.OrganizationalUnit")]
    public partial class OrganizationalUnit :Entity
    {
        public OrganizationalUnit()
        {
            //Employee = new HashSet<Employee>();
            //Prolongation = new HashSet<Prolongation>();
            //Question = new HashSet<Question>();
            //Reservation = new HashSet<Reservation>();
            ShortName = String.Empty;
            IsActive = true;
            DisplayOrder = 0;
            Description = String.Empty;
            Level = 0;
        }

        public int Id { get; set; }

        [StringLength(10)]
        public string ShortName { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public int DisplayOrder { get; set; }
        
        public bool IsActive { get; set; }
        
        public short Level { get; set; }

        //public virtual ICollection<Employee> Employee { get; set; }

        [Required]
        public virtual Organization Organization { get; set; }
        public virtual OrganizationalUnit MasterUnit { get; set; }
        public virtual ICollection<OrganizationalUnit> Subordinates { get; set; }

        //public virtual ICollection<Prolongation> Prolongation { get; set; }

        //public virtual ICollection<Question> Question { get; set; }

        //public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
