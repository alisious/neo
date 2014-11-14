namespace Kseo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cooperation.PersonAlias")]
    public partial class PersonAlias
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string AliasName { get; set; }

        [Required]
        [StringLength(10)]
        public string ValidFromDate { get; set; }

        [StringLength(10)]
        public string ValidToDate { get; set; }

        public int CooperationId { get; set; }
    }
}
