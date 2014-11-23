using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.Model
{
    public abstract class DictionaryItem
    {
        public DictionaryItem()
        {
            ShortName = String.Empty;
            LongName = String.Empty;
            DisplayOrder = 0;
            IsActive = true;
            Subitems = new HashSet<DictionaryItem>();
        }

        public int Id { get; set; }

        [StringLength(10)]
        public string ShortName { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string LongName { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }
        public virtual DictionaryItem Masteritem { get; set; }
        public virtual ICollection<DictionaryItem> Subitems { get; set; }  

    }

    [Table("Person.Country")]
    public partial class Country : DictionaryItem { }
}
