using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
  public partial  class Avaliacao_Terapia_Ocupacional
    {
        [StringLength(1)]
        public string avaliacao_prorrogacao { get; set; }

        public int Id { get; set; }

        public DateTime? d_data { get; set; }

        public int id_paciente { get; set; }

        public string diagnostico { get; set; }

        public string responsavel_paciente { get; set; }

        public string grau_parentesco_responsavel { get; set; }

        public string presente_na_avaliacao { get; set; }

        public string possui_cuidador { get; set; }

        public string cuidador { get; set; }

        public string condicoes_socioeconomicas { get; set; }

        public string casa_propria { get; set; }

        public string reside_familiares { get; set; }

        public string quantos_familiares { get; set; }


        public string fc { get; set; }


        public string bpmpa { get; set; }


        public string pa { get; set; }

        public string pa2 { get; set; }



        public string fr { get; set; }


        public string rpmsato2 { get; set; }


        public string anamnese_queixa_duracao { get; set; }


        public string historia_molestia { get; set; }


        public string patologias_associadas_has { get; set; }


        public string patologias_associadas_dm { get; set; }


        public string patologias_associadas_outros { get; set; }


        public string fatores_risco_etilista { get; set; }


        public string fatores_risco_tabagista { get; set; }


        public string fatores_risco_outros { get; set; }


        public string info_complementar_via_horal { get; set; }


        public string info_complementar_sne { get; set; }


        public string info_complementar_gtt { get; set; }

        public string info_complementar_outros { get; set; }


        public string elimininacao_fisiologica_controle_total { get; set; }


        public string elimininacao_fisiologica_fraldas { get; set; }


        public string elimininacao_fisiologica_outros { get; set; }


        public string avaliacao_neuro_orientado { get; set; }


        public string avaliacao_neuro_desorientado { get; set; }


        public string avaliacao_neuro_confusao { get; set; }


        public string avaliacao_neuro_calmo { get; set; }


        public string avaliacao_neuro_agressivo { get; set; }


        public string avaliacao_neuro_agitado { get; set; }


        public string avaliacao_osteomuscular_acamado { get; set; }


        public string avaliacao_osteomuscular_deambula { get; set; }

        public string avaliacao_osteomuscular_auxilio_terceiros { get; set; }


        public string avaliacao_osteomuscular_auxilio_andador { get; set; }


        public string avaliacao_osteomuscular_auxilio_bengala_quatro { get; set; }


        public string avaliacao_osteomuscular_auxilio_bengala_um { get; set; }


        public string avaliacao_osteomuscular_auxilio_sem_auxilio { get; set; }


        public string marcha { get; set; }


        public string avaliacao_osteomuscular_atividade_diaria { get; set; }


        public string avaliacao_ocupacional { get; set; }


        public string grau_dificuldade { get; set; }

        public string observacoes_gerais { get; set; }

        public string plano_tratamento { get; set; }

        public string orientacao_cuidador { get; set; }

        public string programa_tratamento { get; set; }

        public string nivel_complexidade { get; set; }

        public string fase_patologia { get; set; }

        public string foco_tratamento { get; set; }

        public string condicao_desmame_alta_programa { get; set; }

        public string proposta_tratamento { get; set; }

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
