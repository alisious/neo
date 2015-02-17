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
           Location = new Location();
        }
        
        public int Id { get; set; }
        [Required(ErrorMessage = @"Rodzaj adresu jest wymagany!")]
        public virtual AddressType AddressType { get; set; }
        public Location Location  { get; set; }
        
    }
}
