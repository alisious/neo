namespace Kseo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cooperation.ConductingOfficer")]
    public partial class ConductingOfficer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string StartDate { get; set; }

        [StringLength(10)]
        public string EndDate { get; set; }

        public int Employee_Id { get; set; }

        public int ConductingUnit_Id { get; set; }
    }
}
