using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fisaep.Data
{
    public class Avaliacao_Fisioterapia_Infantil
    {
        [StringLength(1)]
        public string avaliacao_prorrogacao { get; set; }

        public int Id { get; set; }

        public DateTime? d_data { get; set; }

        public int id_paciente { get; set; }

        public string diagnostico { get; set; }

        public string anamnese_queixa_duracao { get; set; }

        public string historia_molestia { get; set; }

        public string gestacao_doenca_existentes { get; set; }

        public string gestacao_doenca_existentes_qual { get; set; }

        public string gestacao_tratado { get; set; }

        public string gestacao_tratado_medicamentos { get; set; }

        public string gestacao_grupo_sanguineo { get; set; }

        public string gestacao_grupo_sanguineo_rh { get; set; }

        public string outras_gestacao_mais_filhos { get; set; }


        public string outras_gestacao_quantos { get; set; }


        public string outras_gestacao_ordem { get; set; }


        public string outras_gestacao_deficiencia { get; set; }

        public string outras_gestacao_deficiencia_qual_filho { get; set; }


        public string outras_gestacao_deficiencia_qual { get; set; }


        public string outras_gestacao_historia_aborto { get; set; }

        public string gravidez_pre_natal { get; set; }


        public string gravidez_pre_natal_local { get; set; }


        public string gravidez_pre_natal_medico { get; set; }


        public string desenvolvimento_gravidez_normal { get; set; }


        public string desenvolvimento_gravidez_alteracoes_quais { get; set; }


        public string gravidez_hemorragias { get; set; }


        public string gravidez_acidentes { get; set; }




        public string gravidez_diabetes { get; set; }

        public string gravidez_raio_x { get; set; }


        public string gravidez_raio_x_quantos { get; set; }


        public string gravidez_vomitos { get; set; }


        public string gravidez_infeccoes { get; set; }


        public string gravidez_outras_alteracoes { get; set; }


        public string gravidez_duracao_deste_filho { get; set; }


        public string gravidez_planejada { get; set; }


        public string gravidez_crianca_desejada { get; set; }


        public string parto_quantas_semanas { get; set; }


        public string parto_tipo { get; set; }


        public string parto_duracao { get; set; }


        public string parto_circular_cordao { get; set; }

        public string parto_forceps { get; set; }


        public string parto_medico { get; set; }


        public string parto_intercorrencias { get; set; }


        public string parto_apgar { get; set; }


        public string parto_chorou { get; set; }


        public string parto_cianose { get; set; }


        public string parto_peso { get; set; }


        public string parto_altura { get; set; }


        public string parto_ictericia { get; set; }


        public string parto_mal_formacao { get; set; }


        public string parto_incubadora { get; set; }


        public string parto_normalidade { get; set; }


        public string amamentacao_mama_atualmente { get; set; }


        public string amamentacao_alimenta_mais_algo { get; set; }


        public string amamentacao_idade_deixou_mamar { get; set; }


        public string amamentacao_tempo_leite_peito { get; set; }


        public string historia_alguma_doenca { get; set; }


        public string historia_alguma_doenca_qual { get; set; }


        public string historia_hospitalizado { get; set; }


        public string historia_hospitalizado_quantas { get; set; }


        public string historia_doencas { get; set; }


        public string historia_doencas_qual { get; set; }


        public string historia_doencas_semana { get; set; }


        public string historia_doencas_semana_qual { get; set; }


        public string historia_medicacao { get; set; }


        public string historia_medicacao_qual { get; set; }


        public string historia_cirurgias { get; set; }




        public string historia_cirurgias_qual { get; set; }


        public string historia_sono{ get; set; }

        public string historia_fraldas { get; set; }


        public string historia_fraldas_retirou_idade { get; set; }


        public string historia_alimentacao{ get; set; }



        public string historia_tipo_alimentacao { get; set; }






        public string humor_habitual { get; set; }


        public string comunicativo { get; set; }


        public string brinca_criancas { get; set; }


        public string avds_casa { get; set; }


        public string relacionamento_familia { get; set; }


        public string relacionamento_pais_crianca { get; set; }


        public string vacinas_bcg { get; set; }

        public string vacinas_triplice { get; set; }


        public string vacinas_sabin { get; set; }


        public string vacinas_sarampo { get; set; }


        public string vacinas_rubeola { get; set; }


        public string vacinas_outras { get; set; }


        public string esquema_corporal_ausente { get; set; }


        public string dominio_lateral_mao_direita { get; set; }


        public string dominio_lateral_mao_esquerda { get; set; }


        public string dominio_lateral_pe_direita { get; set; }


        public string dominio_lateral_pe_esquerda { get; set; }

        public string deslocamento_cabeca_objetos { get; set; }


        public string fixacao_olhar { get; set; }


        public string acompanhamento_objetivos { get; set; }


        public string nistagmo { get; set; }


        public string identificacao_som { get; set; }


        public string leva_mao_boca { get; set; }


        public string leva_pe_boca { get; set; }


        public string rolou { get; set; }


        public string rolou_idade { get; set; }


        public string arrastou { get; set; }




        public string arrastou_idade { get; set; }


        public string engatinhou { get; set; }

        public string engatinhou_idade { get; set; }


        public string andou { get; set; }


        public string andou_idade { get; set; }

        public string reacao_protecao_frente { get; set; }

        public string reacao_protecao_lado { get; set; }

        public string reacao_protecao_tras { get; set; }


        public string reacao_equilibrio_frente { get; set; }

        public string reacao_equilibrio_lado { get; set; }

        public string reacao_equilibrio_tras { get; set; }

        public string coordenacao_motora_grossa { get; set; }

        public string coordenacao_motora_fina { get; set; }


        public string observacoes_gerais { get; set; }


        public string plano_tratamento { get; set; }


        public string programa_tratamento { get; set; }

        public string nivel_complexidade { get; set; }

        public string fase_patologia { get; set; }

        public string foco_tratamento { get; set; }

        public string condicao_desmame_alta_programa { get; set; }

        public string proposta_atendimento { get; set; }

        public DateTime data_inclusao { get; set; }

        public string usuario_inclusao { get; set; }

        public int? id_especialista { get; set; }

        public string modo_texto { get; set; }

        public string modo_texto_2 { get; set; }

        public DateTime? DataAutorizacao { get; set; }

        public string UsuarioAutorizacao { get; set; }

        public DateTime? DataNegativa { get; set; }

        public string UsuarioNegativa { get; set; }

        public string url_imagem { get; set; }
        public string url_imagem2 { get; set; }
        public string url_imagem3 { get; set; }
        public string url_imagem4 { get; set; }
        public string url_imagem5 { get; set; }
    }
}