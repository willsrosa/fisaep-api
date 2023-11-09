namespace Fisaep.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Especialista_Email
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string c_descricao { get; set; }

        public int id_especialista { get; set; }

        public DateTime? data_inclusao { get; set; }

        public DateTime? data_exclusao { get; set; }

        [StringLength(128)]
        public string usuario_inclusao { get; set; }

        [StringLength(128)]
        public string usuario_exclusao { get; set; }

        public virtual Cadastro_Especialista Cadastro_Especialista { get; set; }
    }
}
