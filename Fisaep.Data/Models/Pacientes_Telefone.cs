namespace Fisaep.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Pacientes_Telefone
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string c_telefone { get; set; }

        [StringLength(150)]
        public string c_descricao { get; set; }

        public int? id_paciente { get; set; }

        public DateTime? data_inclusao { get; set; }

        public DateTime? data_exclusao { get; set; }

        [StringLength(128)]
        public string usuario_inclusao { get; set; }

        [StringLength(128)]
        public string usuario_exclusao { get; set; }

        public virtual Cadastro_Pacientes Cadastro_Pacientes { get; set; }
    }
}
