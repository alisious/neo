using Kseo2.Model;

namespace Kseo2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Common.Employee")]
    public partial class Employee
    {
        public Employee()
        {}

        [Required]
        public int Id { get; set; }

        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        public Rank Rank { get; set; }
        public virtual OrganizationalUnit OrganizationalUnit { get; set; }

        public override string ToString()
        {
            return String.Format("{0}{1}{2}",
                (Rank!=null)?String.Concat(Rank.ShortName," "):String.Empty,
                LastName,
                !String.IsNullOrWhiteSpace(FirstName)?String.Concat(" ",FirstName):String.Empty);
        
        }
    }
}
