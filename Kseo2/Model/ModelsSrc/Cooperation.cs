namespace Kseo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cooperation.Cooperation")]
    public partial class Cooperation
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string RegNum { get; set; }

        [Required]
        [StringLength(10)]
        public string StartDate { get; set; }

        [Column(TypeName = "ntext")]
        public string Notes { get; set; }

        [StringLength(10)]
        public string EndDate { get; set; }

        public int? EndReason_Id { get; set; }

        public int RankGroup_Id { get; set; }

        public int ObtainingBase_Id { get; set; }

        public int Person_Id { get; set; }

        public DateTime CreationTime { get; set; }

        public int Creator_Id { get; set; }

        public DateTime? RegEndTime { get; set; }

        public int? RegEndOperator_Id { get; set; }
    }
}
