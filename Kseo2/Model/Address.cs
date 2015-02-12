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
            IsCurrent = true;
        }

        public int Id { get; set; }
        [Required]
        public bool IsCurrent { get; set; }
        [Required(ErrorMessage = @"Rodzaj adresu jest wymagany!")]
        [MaxLength(20,ErrorMessage = @"Rodzaj adresu może składać się najwyżej z 20 znaków!")]
        public string AddressType { get; set; }
        [Required(ErrorMessage = @"Adres jest wymagany")]
        [MaxLength(200,ErrorMessage = @"Adres nie może być dłuższy niż 200 znaków!")]
        public string Notes  { get; set; }
 
    }
}
