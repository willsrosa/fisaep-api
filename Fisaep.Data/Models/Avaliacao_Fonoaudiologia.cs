using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
    public partial class Avaliacao_Fonoaudiologia
    {
        [StringLength(1)]
        public string avaliacao_prorrogacao { get; set; }

        public int Id { get; set; }

        public DateTime? d_data { get; set; }

        public int id_paciente { get; set; }

        public string diagnostico { get; set; }

        public string anamnese_queixa_duracao { get; set; }

        public string historia_pregressa { get; set; }

        public string patologias { get; set; }

        public string patologias_outros { get; set; }

        public string aspectos_cuidador { get; set; }

        public string aspectos_cuidador_apto { get; set; }

        public string condicoes_socioeconomicas { get; set; }

        public string obs_estado_vigilia { get; set; }

        public string liguagem_receptiva { get; set; }

        public string liguagem_expressiva { get; set; }

        public string avaliacao_osteomuscular_acamado { get; set; }

        public string avaliacao_osteomuscular_deambula { get; set; }

        public string avaliacao_osteomuscular_se_com_auxilio { get; set; }

        public string avaliacao_osteomuscular_realiza_avds { get; set; }

        public string avaliacao_respiratoria_respiracao { get; set; }

        public string avaliacao_respiratoria_oxigenio_terapia { get; set; }

        public string intubacao_orotraqueal { get; set; }

        public string intubacao_orotraqueal_tempo { get; set; }

        public string pneumonia_broncoaspiracao { get; set; }

        public string pneumonia_broncoaspiracao_quantidade { get; set; }

        public string traqueostomizado { get; set; }

        public string teste_bluedye { get; set; }

        public string avaliacao_orgaos_fonoarticulatorios { get; set; }

        public string lingua_anormalidades_estruturais { get; set; }

        public string lingua_adequacao_higiene { get; set; }

        public string lingua_frenulo_lingual { get; set; }

        public string lingua_marcas_dentarias { get; set; }

        public string lingua_assoalho_boca { get; set; }

        public string lingua_frenulo_lingual_curto { get; set; }

        public string lingua_assoalho_boca_flacidez { get; set; }

        public string lingua_lesoes_orais { get; set; }

        public string lingua_volumosa { get; set; }

        public string lingua_alargada { get; set; }

        public string mobilidade_lingua { get; set; }

        public string sensibilidade_lingua { get; set; }

        public string postura_habitual_labios { get; set; }

        public string mobilidade_labios { get; set; }

        public string tonus_labios { get; set; }

        public string esficter_labial { get; set; }

        public string sensibilidade_labios { get; set; }

        public string palato_duro { get; set; }

        public string estrutura_veu_palatino { get; set; }

        public string modo_respiratorio { get; set; }

        public string tonus_bocheca { get; set; }

        public string sensibilidade_bochecha { get; set; }

        public string elementos_dentarios { get; set; }

        public string ingesta_dieta_pastosa_normal { get; set; }

        public string engasgos_presentes { get; set; }

        public string tosse_antes { get; set; }

        public string tosse_durante { get; set; }

        public string tosse_apos { get; set; }

        public string ausencia_tosse { get; set; }

        public string escape_oral { get; set; }

        public string residuos_cavidade { get; set; }

        public string regurgitacao_nasal { get; set; }

        public string sem_alteracoes_vocais { get; set; }

        public string voz_molhada { get; set; }

        public string ingesta_dieta_solida_normal { get; set; }

        public string mastigacao { get; set; }

        public string unilateral_direita { get; set; }

        public string unilateral_esquerda { get; set; }

        public string bilateral { get; set; }

        public string ciclos_mastigatorios { get; set; }

        public string ausente_mastigacao { get; set; }

        public string ciclos_mastigatorios_adequados { get; set; }

        public string degluticao_normal { get; set; }

        public string engasgos_presente { get; set; }

        public string tosse_antes_degluticao { get; set; }

        public string tosse_durante_degluticao { get; set; }

        public string tosse_apos_degluticao { get; set; }

        public string ausencia_tosse_degluticao { get; set; }

        public string escape_oral_degluticao { get; set; }

        public string residuos_cavidade_degluticao { get; set; }

        public string regurgitacao_nasal_degluticao { get; set; }

        public string sem_alteracoes_vocais_degluticao { get; set; }

        public string voz_molhada_degluticao { get; set; }

        public string ingesta_dieta_liquida_normal { get; set; }

        public string ingesta_dieta_liquida_engasgos_presente { get; set; }

        public string ingesta_dieta_liquida_tosse_antes { get; set; }

        public string ingesta_dieta_liquida_tosse_durante { get; set; }

        public string ingesta_dieta_liquida_tosse_apos { get; set; }

        public string ingesta_dieta_liquida_ausencia_tosse { get; set; }

        public string ingesta_dieta_liquida_escape_oral { get; set; }

        public string ingesta_dieta_liquida_residuos_cavidade { get; set; }

        public string ingesta_dieta_liquida_regurgitacao_nasal { get; set; }

        public string ingesta_dieta_liquida_sem_alteracoes_vocais { get; set; }

        public string ingesta_dieta_liquida_voz_molhada { get; set; }

        public string hipotese_diagnostica_fono { get; set; }

        public string escala_fois { get; set; }

        public string escala_oneil { get; set; }

        public string conduta_fono { get; set; }

        public string programacao_tratamento { get; set; }

        public string nivel_complexidade { get; set; }

        public string foco_tratamento { get; set; }
        
        public string condicao_desmame_alta_programa { get; set; }

        public DateTime? data_inclusao { get; set; }

        public string usuario_inclusao { get; set; }

        public string modo_texto { get; set; }

        public string modo_texto_2 { get; set; }

        public DateTime? DataAutorizacao { get; set; }

        public string UsuarioAutorizacao { get; set; }

        public DateTime? DataNegativa { get; set; }

        public string UsuarioNegativa { get; set; }

        public int? id_especialista { get; set; }

        public string url_imagem { get; set; }
        public string url_imagem2 { get; set; }
        public string url_imagem3 { get; set; }
        public string url_imagem4 { get; set; }
        public string url_imagem5 { get; set; }
    }
}
