namespace Fisaep.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Paciente_Internacao
    {
        public int Id { get; set; }

        public DateTime d_internacao { get; set; }

        public DateTime? d_previsao_alta { get; set; }

        public DateTime? d_alta { get; set; }

        public int id_paciente { get; set; }

        public DateTime? data_inclusao { get; set; }

        public DateTime? data_exclusao { get; set; }

        [StringLength(128)]
        public string usuario_inclusao { get; set; }

        [StringLength(128)]
        public string usuario_exclusao { get; set; }

        public virtual Cadastro_Pacientes Cadastro_Pacientes { get; set; }
    }
}
