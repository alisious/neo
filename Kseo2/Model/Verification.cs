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
        public Verification(User author, Question question = null)
        {
            Answer = String.Empty;
            Notes = String.Empty;
            Question = question ?? new Question();
            Author = author;
            Citizenships = new HashSet<Country>();
        }

        public int Id { get; set; }

        [StringLength(11)]
        public string Pesel { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string FatherName { get; set; }
        [StringLength(50)]
        public string MotherName { get; set; }
        [StringLength(50)]
        public string MotherMaidenName { get; set; }
        [StringLength(10)]
        public string BirthDate { get; set; }
        [StringLength(100)]
        public string BirthPlace { get; set; }

        [Column(TypeName = "ntext")]
        public string Answer { get; set; }

        public bool IsRegistered { get; set; }


        [Column(TypeName = "ntext")]
        public string Notes { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreationTime { get; set; }

        public virtual QuestionReason QuestionReason { get; set; }
        public User Author { get; set; }
        public Question Question { get; set; }

        public virtual Person FoundedPerson { get; set; }

        public ICollection<Country> Citizenships { get; set; }
        public Country Nationality { get; set; }
       
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
