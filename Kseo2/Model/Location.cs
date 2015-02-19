using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.Model
{
    [ComplexType]
    public class Location
    {
       
        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(100)]
        public string Street { get; set; }
        [MaxLength(10)]
        public string StreetNo { get; set; }
        [MaxLength(10)]
        public string PlaceNo { get; set; }
        [MaxLength(6)]
        public string PostalCode { get; set; }
        [MaxLength(100)]
        public string PostOffice { get; set; }

        public override string ToString()
        {
            return String.Format("{0}{1} {2}{3}",
                    City,
                    String.IsNullOrWhiteSpace(Street) ? String.Empty : String.Concat(", ",Street),
                    StreetNo,
                    String.IsNullOrWhiteSpace(PlaceNo) ? String.Empty : String.Concat("/",PlaceNo));
        }
        
    }
}
