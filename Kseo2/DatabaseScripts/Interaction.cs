namespace Kseo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cooperation.Interaction")]
    public partial class Interaction
    {
        public int Id { get; set; }

        public int Category_Id { get; set; }

        [Required]
        [StringLength(10)]
        public string StartDate { get; set; }

        [StringLength(10)]
        public string EndDate { get; set; }

        public int Cooperation_Id { get; set; }
    }
}
