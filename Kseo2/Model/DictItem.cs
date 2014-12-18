using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.Model
{
    public abstract class DictItem :IEntity
    {
        public DictItem()
        {
            ShortName = String.Empty;
            Description = String.Empty;
            DisplayOrder = 0;
            IsActive = true;
            Subitems = new HashSet<DictItem>();
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
        public virtual DictItem Masteritem { get; set; }
        public virtual ICollection<DictItem> Subitems { get; set; }

        public override string ToString()
        {
            return Name;
        }

        [NotMapped]
        public EntityState EntityState { get; set; }
    }

    [Table("Reservation.ReservationEndReason")]
    public class ReservationEndReason : DictItem{}

}
