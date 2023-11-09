namespace Fisaep.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Especialista_Paciente_Permissao
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Especialista_Paciente_Permissao()
        //{
        //    Especialista_Paciente = new HashSet<Especialista_Paciente>();
        //}

        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string c_descricao { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Especialista_Paciente> Especialista_Paciente { get; set; }
    }
}
