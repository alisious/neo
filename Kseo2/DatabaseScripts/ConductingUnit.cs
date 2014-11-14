namespace Kseo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cooperation.ConductingUnit")]
    public partial class ConductingUnit
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string StartDate { get; set; }

        [StringLength(10)]
        public string EndDate { get; set; }

        public int OrganizationalUnit_Id { get; set; }

        public int Cooperation_Id { get; set; }
    }
}
