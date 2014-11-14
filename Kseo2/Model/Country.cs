namespace Kseo2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person.Country")]
    public partial class Country
    {
        public Country()
        {
            DisplayOrder = 0;
            IsActive = true;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string LongName { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }

    
    }
}
