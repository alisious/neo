using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.Model
{
    [Table("Person.Address")]
    public class Address :Entity
    {

        public Address()
        {
            IsActive = true;
        }

        public int Id { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required(ErrorMessage = @"Rodzaj adresu jest wymagany!")]
        public virtual AddressType AddressType { get; set; }
        [Required(ErrorMessage = @"Adres jest wymagany")]
        [MaxLength(200,ErrorMessage = @"Adres nie może być dłuższy niż 200 znaków!")]
        public string Location  { get; set; }

        [NotMapped]
        public string IsCurrentImage
        {
            get { return IsActive ? @"..\Images/ok_mark.png" : String.Empty; }
        }
 
    }
}
