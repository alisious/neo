namespace Kseo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Issue.InvolvedPerson")]
    public partial class InvolvedPerson
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string StartDate { get; set; }

        [StringLength(10)]
        public string EndDate { get; set; }

        [Column(TypeName = "ntext")]
        public string Notes { get; set; }

        public int InvolveType_Id { get; set; }

        public int Issue_Id { get; set; }

        public int Person_Id { get; set; }

        public DateTime CreationTime { get; set; }

        public int Creator_Id { get; set; }
    }
}
