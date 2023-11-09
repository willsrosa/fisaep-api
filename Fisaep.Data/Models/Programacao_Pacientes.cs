namespace Fisaep.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Programacao_Pacientes
    {
        public int Id { get; set; }

        public int id_especialidade { get; set; }

        public DateTime d_inicio_programacao { get; set; }

        public DateTime d_termino_programacao { get; set; }

        public DateTime? d_limite_envio_faturamento { get; set; }

        public int n_limite { get; set; }

        public int id_paciente { get; set; }

        public int id_programa { get; set; }

        public DateTime? data_inclusao { get; set; }

        public DateTime? data_exclusao { get; set; }

        [StringLength(128)]
        public string usuario_inclusao { get; set; }

        [StringLength(128)]
        public string usuario_exclusao { get; set; }

        [StringLength(500)]
        public string obs_termino { get; set; }

        public string mes_copia { get; set; }

        public int? pads_cobranca { get; set; }

        public string motivo_diferenca_pad { get; set; }

        public DateTime? data_confirmacao { get; set; }
        public string usuario_confirmacao { get; set; }

    }
}
