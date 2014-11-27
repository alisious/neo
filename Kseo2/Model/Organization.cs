namespace Kseo2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Common.Organization")]
    public partial class Organization :Entity
    {
        public Organization()
        {
            OrganizationalUnits = new HashSet<OrganizationalUnit>();
            //Questions = new HashSet<Question>();
            ShortName = String.Empty;
            IsActive = true;
            DisplayOrder = 0;
            Description = String.Empty;
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

        public virtual ICollection<OrganizationalUnit> OrganizationalUnits { get; set; }
        //public virtual ICollection<Question> Questions { get; set; }
        
    }
}
