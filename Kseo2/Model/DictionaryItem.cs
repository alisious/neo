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
    public abstract class DictionaryItem<T> :IEntity where T :class
    {
        protected DictionaryItem()
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

        public EntityState EntityState { get; set; }
    }

    [Table("Person.Country")]
    public class Country : DictionaryItem<Country> {}
    [Table("Verification.QuestionForm")]
    public class QuestionForm : DictionaryItem<QuestionForm> { }
    [Table("Verification.QuestionReason")]
    public class QuestionReason : DictionaryItem<QuestionReason> { }
    [Table("Common.Rank")]
    public class Rank :DictionaryItem<Rank> {}
    [Table("Common.Organization")]
    public class Organization : DictionaryItem<Organization> { }
    [Table("Person.AddressType")]
    public class AddressType : DictionaryItem<AddressType> { }
    //Reservation
    [Table("Reservation.ReservationPurpose")]
    public class ReservationPurpose : DictionaryItem<ReservationPurpose> { }
    [Table("Reservation.ReservationEndReason")]
    public class ReservationEndReason :DictionaryItem<ReservationEndReason> { }


}
