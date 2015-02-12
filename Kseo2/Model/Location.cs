using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.Model
{
    public abstract class Location :Entity
    {
        public int Id { get; set; } 
        
        [Required]
        public string City { get; set; }
        public string Street { get; set; }
        [Required]
        public string StreetNo { get; set; }
        public string PlaceNo { get; set; }
        public string PostalCode { get; set; }
        public string PostOffice { get; set; }

        [NotMapped]
        public string InLine
        {
            get
            {
                return String.Format("{0}{1} {2}{3}",
                    City,
                    String.IsNullOrWhiteSpace(Street) ? String.Empty : String.Concat(", ",Street),
                    StreetNo,
                    String.IsNullOrWhiteSpace(PlaceNo) ? String.Empty : String.Concat("/",PlaceNo));
            }
        }
        
    }
}
