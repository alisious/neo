﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.Model
{
    public abstract class DictionaryItem<T> where T :class
    {
        public DictionaryItem()
        {
            ShortName = String.Empty;
            Description = String.Empty;
            DisplayOrder = 0;
            IsActive = true;
            Subitems = new HashSet<T>();
        }

        public int Id { get; set; }

        [StringLength(10)]
        [DisplayName("Skrót")]
        public string ShortName { get; set; }
        
        [Required]
        [StringLength(100)]
        [Index("INX_NAME", IsUnique = true)]
        [DisplayName("Nazwa")]
        public string Name { get; set; }

        [StringLength(200)]
        [DisplayName("Opis")]
        public string Description { get; set; }

        [DisplayName("Kolejność")]
        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }
        public virtual T Masteritem { get; set; }
        public virtual ICollection<T> Subitems { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    [Table("Person.Country")]
    public partial class Country : DictionaryItem<Country> {}
    [Table("Verification.QuestionForm")]
    public partial class QuestionForm : DictionaryItem<QuestionForm> { }
    [Table("Verification.QuestionReason")]
    public partial class QuestionReason : DictionaryItem<QuestionReason> { }
    [Table("Common.Rank")]
    public partial class Rank :DictionaryItem<Rank> {}

    
}
