namespace Kseo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Common.OrganizationalUnit")]
    public partial class OrganizationalUnit
    {
        public OrganizationalUnit()
        {
            Employee = new HashSet<Employee>();
            Prolongation = new HashSet<Prolongation>();
            Question = new HashSet<Question>();
            Reservation = new HashSet<Reservation>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string FullName { get; set; }

        public int DisplayOrder { get; set; }

        public int? MasterUnit_Id { get; set; }

        public int Organization_Id { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual ICollection<Prolongation> Prolongation { get; set; }

        public virtual ICollection<Question> Question { get; set; }

        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
