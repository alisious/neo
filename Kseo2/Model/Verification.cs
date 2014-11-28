namespace Kseo2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Verification.Verification")]
    public class Verification :Entity
    {
        public Verification()
        {
            ResultsNote = String.Empty;
            Notes = String.Empty;

        }

        public int Id { get; set; }

        [StringLength(11)]
        public string Pesel { get; set; }
        [StringLength(50)]
        public string Imiona { get; set; }
        [StringLength(50)]
        public string Nazwiska { get; set; }
        [StringLength(50)]
        public string ImieOjca { get; set; }
        [StringLength(50)]
        public string ImieMatki { get; set; }
        [StringLength(50)]
        public string NazwiskoRodoweMatki { get; set; }
        [StringLength(10)]
        public string DataUrodzenia { get; set; }
        [StringLength(100)]
        public string MiejsceUrodzenia { get; set; }

        [Column(TypeName = "ntext")]
        public string ResultsNote { get; set; }

        public bool IsRegistered { get; set; }
        
        [StringLength(2)]
        public string KlauzulaOdpowiedzi { get; set; }
        [Column(TypeName = "ntext")]
        public string TrescOdpowiedzi { get; set; }


        [Column(TypeName = "ntext")]
        public string Notes { get; set; }
        
        public DateTime CreationTime { get; set; }

        public virtual QuestionReason QuestionReason { get; set; }
        public virtual Operator Operator { get; set; }
        public virtual Question Question { get; set; }
        public virtual Person Person { get; set; }

        public Odpowiedz Odpowiedz {get; protected set; }


    }


    public class Odpowiedz
    {
        
        [StringLength(2)]
        public string Klauzula { get; set; }
        [StringLength(1)]
        public string CzyFiguruje { get; set; }
        [Column(TypeName = "ntext")]
        public string Tresc { get; set; }

    }
}
