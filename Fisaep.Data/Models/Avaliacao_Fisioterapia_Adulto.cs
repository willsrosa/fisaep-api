namespace Fisaep.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Avaliacao_Fisioterapia_Adulto
    {
        [StringLength(1)]
        public string avaliacao_prorrogacao { get; set; }

        public int Id { get; set; }

        public DateTime? d_data { get; set; }

        public int? id_paciente { get; set; }

        [StringLength(100)]
        public string c_responsavel_paciente { get; set; }

        public string n_grau_parentesco_responsavel { get; set; }

        public int? possui_cuidados { get; set; }

        public int? n_presente_avaliacao { get; set; }

        public int? n_ambiente_domiciliar { get; set; }

        public int? n_cuidador_apto { get; set; }

        public int? n_condicoes_socioeconimicas { get; set; }

        public int? n_casa_propria { get; set; }

        public int? n_reside_familiares { get; set; }

        public string n_grau_parentesco_familiar { get; set; }

        public int? n_saturacao { get; set; }

        public int? n_frequencia_respiratoria { get; set; }

        public int? n_frequencia_cardiaca { get; set; }

        public int? n_pressao_arterial_1 { get; set; }

        public int? n_pressao_arterial_2 { get; set; }

        [Column(TypeName = "text")]
        public string c_anamnese { get; set; }

        [Column(TypeName = "text")]
        public string c_historia_molesia { get; set; }

        public int? n_has { get; set; }

        public int? n_dm { get; set; }

        [StringLength(150)]
        public string c_outros_patologias_associadas { get; set; }

        public int? n_etilista { get; set; }

        public int? n_tabagista { get; set; }

        [StringLength(150)]
        public string c_outros_fator_risco { get; set; }

        public int? n_alimento_via_oral { get; set; }

        public int? n_sne { get; set; }

        public int? n_gtt { get; set; }

        [StringLength(150)]
        public string c_informacoes_complementares_outros { get; set; }

        public int? n_eliminacoes_fisicas { get; set; }

        public int? n_controle_total { get; set; }

        public int? n_uso_fraldas { get; set; }

        [StringLength(150)]
        public string c_informacoes_complementares_outros_2 { get; set; }

        public int? n_orientado { get; set; }

        public int? n_desorientado { get; set; }

        public int? n_periodo_confusao { get; set; }

        public int? n_calmo { get; set; }

        public int? n_agressivo { get; set; }

        public int? n_agitado { get; set; }

        public int? n_acamado { get; set; }

        public int? n_com_auxilio { get; set; }

        public int? n_terceiro { get; set; }

        public int? n_andador { get; set; }

        public int? n_bengala { get; set; }

        public int? n_bengala_quatro_pontas { get; set; }

        public int? n_bengala_um_ponto { get; set; }

        public int? n_sem_auxilio { get; set; }

        [Column(TypeName = "text")]
        public string n_marcha { get; set; }

        public int? n_realiza_atividades_fisicas { get; set; }

        public int? n_movimentos_articular { get; set; }

        public int? n_sedestacao_ortostatismo { get; set; }

        public int? n_ortostatismo_sedacao { get; set; }

        public int? n_sedentacao_descubito_dorsal { get; set; }

        public int? n_decubito_dorsal_ventral { get; set; }

        public int? n_decubito_vental_dorsal { get; set; }

        public int? n_sedestacao { get; set; }

        public int? n_ortostatismo { get; set; }

        public int? n_massa_corporal { get; set; }

        public int? n_tonus_muscular { get; set; }

        public int? n_trofismo_muscular { get; set; }

        public int? n_membro_superior_direito { get; set; }

        public int? n_membro_superior_esquerdo { get; set; }

        public int? n_membro_inferior_direito { get; set; }

        public int? n_membro_inferior_esquerdo { get; set; }

        [Column(TypeName = "text")]
        public string n_membros_observaçoes { get; set; }

        public int? n_cordenacao_motora { get; set; }

        public int? n_deformidade_aparente { get; set; }

        [StringLength(150)]
        public string c_descricao_deformidade_aparente { get; set; }

        public int? n_presenca_escaras { get; set; }

        [StringLength(150)]
        public string c_descricao_presenca_escaras { get; set; }

        public int? n_presenca_edema { get; set; }

        [StringLength(150)]
        public string c_descricao_presenca_endema { get; set; }

        public int? n_padrao_respiratorio { get; set; }

        public int? n_oxigenioterapia { get; set; }

        public int? n_volume_minuto { get; set; }

        public int? n_traqueostomizado { get; set; }

        public int? n_tipo_ventilacao { get; set; }

        [StringLength(150)]
        public string c_equipamento { get; set; }

        [StringLength(150)]
        public string c_parametros { get; set; }

        public int? n_frequencia_uso { get; set; }

        public int? n_padrao_ventilatorio { get; set; }

        public int? n_dispneia { get; set; }

        public int? n_expansibilidade_toracica { get; set; }

        [StringLength(150)]
        public string c_ausculta_pulmonar_fisiologica { get; set; }

        public int? n_sons_pulmonares_patologicos { get; set; }

        public int? n_tosse_presente { get; set; }

        public int? n_tosse_eficaz { get; set; }

        public int? n_tosse_ineficaz { get; set; }

        public int? n_tosse_produtiva { get; set; }

        public int? n_tosse_improdutiva { get; set; }

        public int? n_aspiracao_vias_aereas { get; set; }

        public int? n_caracteristica_secrecao { get; set; }

        [Column(TypeName = "text")]
        public string n_observacoes_gerais { get; set; }

        [Column(TypeName = "text")]
        public string n_plano_tratamento { get; set; }

        public int? n_programa_tratamento_duracao { get; set; }

        public int? n_programa_tratamento_complexibilidade { get; set; }

        public int? n_programa_fase_patologica { get; set; }

        public int? n_programa_foco_tratamento { get; set; }

        public int? n_condicao_desmame { get; set; }

        public int? n_proposta_tratamento { get; set; }

        public int? forma_uso_o2 { get; set; }

        public int? n_traqueostomizado_tipo { get; set; }

        public int? n_media_secrecao { get; set; }

        public DateTime? data_inclusao { get; set; }

        [StringLength(128)]
        public string usuario_inclusao { get; set; }

        public int? id_especialista { get; set; }

        [StringLength(15)]
        public string c_rg { get; set; }

        [StringLength(15)]
        public string c_cpf { get; set; }

        [StringLength(20)]
        public string c_carteirinha { get; set; }

        public int? n_deambula { get; set; }

        public int? n_via_administracao { get; set; }

        public string modo_texto { get; set; }

        public string modo_texto_2 { get; set; }

        public DateTime? DataAutorizacao { get; set; }

        public string UsuarioAutorizacao { get; set; }

        public DateTime? DataNegativa { get; set; }

        public string UsuarioNegativa { get; set; }

        public int? Mucoide { get; set; }
        public int? Mucopurulenta { get; set; }
        public int? Purulenta { get; set; }
        public int? Fluida { get; set; }
        public int? SemiEspessa { get; set; }
        public int? Espessa { get; set; }
        public int? Clara { get; set; }
        public int? Amarelada { get; set; }
        public int? Esverdeada { get; set; }
        public int? PequenaQuantidade { get; set; }
        public int? MediaQuantidade { get; set; }
        public int? GrandeQuantidade { get; set; }
        public string url_imagem { get; set; }
        public string url_imagem2 { get; set; }
        public string url_imagem3 { get; set; }
        public string url_imagem4 { get; set; }
        public string url_imagem5 { get; set; }



    }
}
