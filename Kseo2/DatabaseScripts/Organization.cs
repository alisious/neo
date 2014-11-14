namespace Kseo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Common.Organization")]
    public partial class Organization
    {
        public Organization()
        {
            OrganizationalUnit = new HashSet<OrganizationalUnit>();
            Question = new HashSet<Question>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string FullName { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<OrganizationalUnit> OrganizationalUnit { get; set; }

        public virtual ICollection<Question> Question { get; set; }
    }
}
