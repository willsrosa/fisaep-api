namespace Fisaep.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Nivel_Escolaridade
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nivel_Escolaridade()
        {
            Especialista_Especializacoes = new HashSet<Especialista_Especializacoes>();
        }

        public int Id { get; set; }

        [StringLength(150)]
        public string c_descricao { get; set; }

        public DateTime? data_inclusao { get; set; }

        public DateTime? data_exclusao { get; set; }

        [StringLength(128)]
        public string usuario_inclusao { get; set; }

        [StringLength(128)]
        public string usuario_exclusao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Especialista_Especializacoes> Especialista_Especializacoes { get; set; }
    }
}
