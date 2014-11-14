namespace Kseo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Issue.Issue")]
    public partial class Issue
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string RegNum { get; set; }

        [Required]
        [StringLength(10)]
        public string StartDate { get; set; }

        [StringLength(10)]
        public string EndDate { get; set; }

        [Column(TypeName = "ntext")]
        public string Notes { get; set; }

        public DateTime CreationTime { get; set; }

        public int Creator_Id { get; set; }
    }
}
