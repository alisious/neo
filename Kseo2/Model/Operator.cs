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
    [Table("Common.Operator")]
    public class Operator :Entity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [Index("INX_LOGIN",IsUnique = true)]
        public string Login { get; set; }

        public DateTime CreationTime { get; set; }

    }
}
