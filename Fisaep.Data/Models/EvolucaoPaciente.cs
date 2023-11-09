namespace Fisaep.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EvolucaoPaciente")]
    public partial class EvolucaoPaciente
    {
        public int Id { get; set; }

        public DateTime d_data { get; set; }

        public string d_hora_inicio { get; set; }

        public string d_hora_termino { get; set; }

        [Column(TypeName = "text")]
        public string c_quadro_neurologico { get; set; }

        public int? n_saturacao { get; set; }

        public int? n_frequencia_respiratoria { get; set; }

        public int? n_frequencia_cardiaca { get; set; }

        public int? n_pressao_arterial_1 { get; set; }

        public int? n_pressao_arterial_2 { get; set; }

        [StringLength(200)]
        public string c_ausculta_pulmonar { get; set; }

        [Column(TypeName = "text")]
        public string c_conduta_respiratoria { get; set; }

        public int? n_aspiracao { get; set; }

        public int? n_via_acesso { get; set; }

        public int? n_numero_sonda { get; set; }

        public int? n_aspecto_secrecao { get; set; }

        public int? n_quantidade { get; set; }

        public int? n_usa_oxigenio { get; set; }

        public int? n_dispositivo { get; set; }

        public int? n_litros { get; set; }

        public int? n_usa_aparelho { get; set; }

        [StringLength(250)]
        public string c_descricao_aparelho { get; set; }

        [Column(TypeName = "text")]
        public string c_quadro_motor { get; set; }

        [Column(TypeName = "text")]
        public string c_condulta_motora { get; set; }

        public int? id_paciente { get; set; }

        public int id_especialista { get; set; }

        public int? n_avds { get; set; }

        public int? n_marcha { get; set; }

        public string c_tipo_marcha { get; set; }

        public string c_aspecto_geral { get; set; }

        public string EvolucaoTxt { get; set; }

        public virtual Cadastro_Pacientes Cadastro_Pacientes { get; set; }
    }
}
