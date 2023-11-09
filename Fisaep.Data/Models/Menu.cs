namespace Fisaep.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Menu")]
    public partial class Menu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Menu()
        {
            Grupo_Usuario_Permissao = new HashSet<Grupo_Usuario_Permissao>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string c_descricao { get; set; }

        [Required]
        [StringLength(128)]
        public string n_role { get; set; }

        [Required]
        [StringLength(50)]
        public string c_url { get; set; }

        public DateTime? data_inclusao { get; set; }

        public DateTime? data_exclusao { get; set; }

        [StringLength(128)]
        public string usuario_inclusao { get; set; }

        [StringLength(128)]
        public string usuario_exclusao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grupo_Usuario_Permissao> Grupo_Usuario_Permissao { get; set; }
    }
}
