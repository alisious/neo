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
            
        }

        public int Id { get; set; }

        [StringLength(2)]
        public string Classification { get; set; }

        
        [StringLength(50)]
        public string RegNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime RegDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Asker { get; set; }
                
        [StringLength(50)]
        public string Signer { get; set; }

        [StringLength(100)]
        public string SignerPosition { get; set; }
        
        public virtual Organization AskerOrganization { get; set; }

        public virtual OrganizationalUnit AskerOrganizationalUnit { get; set; }
            
        public virtual Rank AskerRank { get; set; }

        public virtual QuestionForm QuestionForm { get; set; }

        public virtual ICollection<Verification> Verifications { get; set; } 
       

    }
}
