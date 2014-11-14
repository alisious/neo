namespace Kseo2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Common.Operator")]
    public partial class Operator
    {
        public Operator()
        {
            Reservation = new HashSet<Reservation>();
            Reservation1 = new HashSet<Reservation>();
            Reservation2 = new HashSet<Reservation>();
            Verification = new HashSet<Verification>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        public int? Rank_Id { get; set; }

        public int? Postion_Id { get; set; }

        public virtual Position Position { get; set; }

        public virtual Rank Rank { get; set; }

        public virtual ICollection<Reservation> Reservation { get; set; }

        public virtual ICollection<Reservation> Reservation1 { get; set; }

        public virtual ICollection<Reservation> Reservation2 { get; set; }

        public virtual ICollection<Verification> Verification { get; set; }
    }
}
