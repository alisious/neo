namespace Kseo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Verification.Question")]
    public partial class Question
    {
        public Question()
        {
            Verification = new HashSet<Verification>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string DocNum { get; set; }

        public int Form_Id { get; set; }

        public int Reason_Id { get; set; }

        public int AskerOrganization_Id { get; set; }

        public int? AskerUnit_Id { get; set; }

        [StringLength(50)]
        public string Asker { get; set; }

        public int? AskerRank_Id { get; set; }

        public int? SignerPosition_Id { get; set; }

        [StringLength(50)]
        public string Signer { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual OrganizationalUnit OrganizationalUnit { get; set; }

        public virtual Position Position { get; set; }

        public virtual Rank Rank { get; set; }

        public virtual QuestionForm QuestionForm { get; set; }

        public virtual QuestionReason QuestionReason { get; set; }

        public virtual ICollection<Verification> Verification { get; set; }
    }
}
