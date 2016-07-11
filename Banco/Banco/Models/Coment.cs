namespace Banco.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Coment")]
    public partial class Coment
    {
        [Key]
        public int id_comment { get; set; }

        [StringLength(250)]
        public string usuario { get; set; }

        [StringLength(250)]
        public string comment { get; set; }

        public int id_post { get; set; }

        public virtual Post Post { get; set; }
    }
}
