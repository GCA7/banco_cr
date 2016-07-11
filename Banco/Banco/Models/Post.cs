namespace Banco.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Post")]
    public partial class Post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Post()
        {
            Coment = new HashSet<Coment>();
        }

        [Key]
        public int id_post { get; set; }

        [Required]
        [StringLength(250)]
        public string tittle { get; set; }

        [Required]
        [StringLength(250)]
        public string description { get; set; }

        [Required]
        [StringLength(250)]
        public string contenido { get; set; }

        [Required]
        public string image { get; set; }

        public int? likes { get; set; }

        [StringLength(250)]
        public string provincia { get; set; }

        public int? precio { get; set; }

        [StringLength(50)]
        public string lote { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Coment> Coment { get; set; }

    }
}
