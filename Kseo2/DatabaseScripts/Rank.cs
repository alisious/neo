namespace Kseo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Common.Rank")]
    public partial class Rank
    {
        public Rank()
        {
            Operator = new HashSet<Operator>();
            Question = new HashSet<Question>();
        }

        public int Id { get; set; }

        public int? Group_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string FullName { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Operator> Operator { get; set; }

        public virtual ICollection<Question> Question { get; set; }
    }
}
