namespace Kseo2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Verification.Question")]
    public partial class Question :Entity
    {
        public Question()
        {
            //Verification = new HashSet<Verification>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string DocNum { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Asker { get; set; }
                
        [StringLength(50)]
        public string Signer { get; set; }

        [StringLength(100)]
        public string SignerPosition { get; set; }
        
        public virtual Organization Organization { get; set; }

        public virtual OrganizationalUnit OrganizationalUnit { get; set; }
            
        public virtual Rank AskerRank { get; set; }

        public virtual QuestionForm QuestionForm { get; set; }

        //przenieœæ do Verification
        //public virtual QuestionReason QuestionReason { get; set; }

        //public virtual ICollection<Verification> Verification { get; set; }
    }
}
