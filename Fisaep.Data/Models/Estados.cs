namespace Fisaep.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Estados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Estados()
        {
            Cidades = new HashSet<Cidades>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(2)]
        public string c_sigla { get; set; }

        [Required]
        [StringLength(50)]
        public string c_nome { get; set; }

        public DateTime? data_inclusao { get; set; }

        public DateTime? data_exclusao { get; set; }

        [StringLength(20)]
        public string usuario_inclusao { get; set; }

        [StringLength(20)]
        public string usuario_exclusao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cidades> Cidades { get; set; }
    }
}
