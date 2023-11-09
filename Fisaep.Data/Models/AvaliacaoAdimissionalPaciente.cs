namespace Fisaep.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AvaliacaoAdimissionalPaciente")]
    public partial class AvaliacaoAdimissionalPaciente
    {
        public int Id { get; set; }

        [StringLength(15)]
        public string c_cpf { get; set; }

        [StringLength(15)]
        public string c_rg { get; set; }

        [StringLength(20)]
        public string c_carteira { get; set; }

        public DateTime? d_avaliacao { get; set; }

        public int? n_responsavel { get; set; }

        [StringLength(100)]
        public string c_nome_responsavel { get; set; }

        [Column(TypeName = "text")]
        public string c_diagnostico_fisioterapico { get; set; }

        [Column(TypeName = "text")]
        public string c_queixa_principal_duracao { get; set; }

        [Column(TypeName = "text")]
        public string c_historia_progressa { get; set; }

        [Column(TypeName = "text")]
        public string c_patologia_associada { get; set; }

        [Column(TypeName = "text")]
        public string c_dados_complementares { get; set; }

        public int? n_cuidador { get; set; }

        public int? n_condicoes_socioeconomicas { get; set; }

        [StringLength(10)]
        public string n_presenca_rampas { get; set; }

        public int? n_presenca_escadas { get; set; }

        public int? n_abertura_ocular { get; set; }

        public int? n_resposta_verbal { get; set; }

        public int? n_orientado { get; set; }

        public int? n_desorientado { get; set; }

        public int? n_periodo_confusao { get; set; }

        public int? n_calmo { get; set; }

        public int? n_agressivo { get; set; }

        public int? n_agitado { get; set; }

        public int? n_acamado { get; set; }

        public int? n_deambula { get; set; }

        public int? n_realiza_avd { get; set; }

        public int? n_movimentacao_articular { get; set; }

        public int? n_massa_corporal { get; set; }

        public int? n_tonus_muscular { get; set; }

        public int? n_trofismo_muscular { get; set; }

        public int? n_cordernacao_motora { get; set; }

        public int? n_deformidade_aparente { get; set; }

        [StringLength(150)]
        public string c_descricao_deformidade { get; set; }

        public int? n_pressao_arterial { get; set; }

        public int? n_pressao_1 { get; set; }

        public int? n_pressao2 { get; set; }

        public int? n_padrao_respiratorio { get; set; }

        public int? n_via_administracao { get; set; }

        public int? n_litros_minuto { get; set; }

        public int? n_forma_uso { get; set; }

        public int? n_tipo_ventilacao { get; set; }

        [StringLength(150)]
        public string c_descricao_equipamento { get; set; }

        [StringLength(150)]
        public string c_parametros { get; set; }

        public int? n_frequencia_uso { get; set; }

        public int? n_padrao_ventilatorio { get; set; }

        public int? n_ritimo_respiratorio { get; set; }

        public int? n_dispineia { get; set; }

        public int? n_expansidade_toraxica { get; set; }

        public int? n_ausculta_pulmonar_fisiologica { get; set; }

        public int? n_sons_pulmonares_patologicos { get; set; }

        public int? n_tosse_presente { get; set; }

        public int? n_tosse_eficaz { get; set; }

        public int? n_tosse_produtiva { get; set; }

        public int? n_aspiracao_vias_aereas { get; set; }

        public int? n_media_diaria { get; set; }

        public int? n_expectoracao { get; set; }

        public int? n_consistencia { get; set; }

        public int? n_cor { get; set; }

        public int? n_quantidae { get; set; }

        public int? n_frequencia_respiratoria { get; set; }

        public int? n_saturacao { get; set; }

        public int? n_temperatura { get; set; }

        public int? n_frequencia_cardiaca { get; set; }

        public int? n_duracao_tratamento { get; set; }

        public int? n_nivel_complexidade { get; set; }

        public int? n_fase_patologia { get; set; }

        public int? n_foco_tratamento { get; set; }

        public int? n_condicao_desmame_alta_programa { get; set; }

        public int? n_internacoes_ultimo_ano { get; set; }

        public int? n_tempo_internacao { get; set; }

        public int? n_deambulacao { get; set; }

        public int? n_plegias { get; set; }

        public int? n_trofismo { get; set; }

        public int? n_estado_nutricional { get; set; }

        public int? n_avds { get; set; }

        public int? n_alimentacao { get; set; }

        public int? n_ulcera_pressao { get; set; }

        public int? n_nivel_conciencia { get; set; }

        public int? n_secrecao_pulmonar { get; set; }

        public int? n_frequencia_respiratoria_proposta { get; set; }

        public int? n_dependencia { get; set; }

        public int? n_proposta_atendimento { get; set; }

        public int id_paciente { get; set; }

        public virtual Cadastro_Pacientes Cadastro_Pacientes { get; set; }
    }
}
