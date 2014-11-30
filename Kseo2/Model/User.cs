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
    [Table("Common.User")]
    public sealed class User :Entity
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        [Index("INX_LOGIN",IsUnique = true)]
        public string Login { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreationTime { get; set; }

    }
}
