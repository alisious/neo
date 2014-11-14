namespace Kseo2
{
    using Kseo2.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Verification.Verification")]
    public partial class Verification
    {
        public int Id { get; set; }

        public int Person_Id { get; set; }

        public int Question_Id { get; set; }

        [Column(TypeName = "ntext")]
        public string ResultsNote { get; set; }

        public bool IsRegistered { get; set; }

        [Column(TypeName = "ntext")]
        public string Notes { get; set; }

        public int Creator_Id { get; set; }

        public DateTime CreationTime { get; set; }

        public virtual Operator Operator { get; set; }

        public virtual Question Question { get; set; }
        public virtual Person Person { get; set; }
    }
}
