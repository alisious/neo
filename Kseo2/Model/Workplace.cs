using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.Model
{   
    [Table("Person.Workplace")]
    public class Workplace :Entity
    {
        
        public Workplace()
        {
            IsCurrent = true;
        }

        public int Id { get; set; }
        [Required]
        public bool IsCurrent { get; set; }
        [Required(AllowEmptyStrings = false,ErrorMessage = @"Nazwa miejsca pracy jest wymagana!")]
        [MaxLength(200,ErrorMessage = @"Nazwa miejsca pracy nie może być dłuższa niż 200 znaków!")]
        public string Name { get; set; }
        public string UnitNumber { get; set; }
        public string Address { get; set; }
        
    }
}
