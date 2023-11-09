using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
    public partial class Avaliacao_Nutricao
    {
        [StringLength(1)]
        public string avaliacao_prorrogacao { get; set; }

        public int Id { get; set; }

        public int id_paciente { get; set; }

        public int? id_especialista { get; set; }

        public DateTime? d_data { get; set; }

        public string motivo { get; set; }

        public string diagnostico { get; set; }

        public string Historico_Clinico { get; set; }

        public int? Nivel_Assistencia_nutricional { get; set; }

        public string Forma_Alimentecao { get; set; }

        public int? Aceitacao { get; set; }

        public string Tipo_Dieta { get; set; }

        public string Suplementacao { get; set; }

        public string Espessante { get; set; }

        public string Ingestao_Liquidos { get; set; }

        public string Tipo_Dieta_Consistencia { get; set; }

        public string Tipo_Quantidade_Suplementacao { get; set; }


        public string Tipo_Quantidade_Espessante { get; set; }


        public string Observacao_Alimentacao { get; set; }


        public int Colica_Dor_Abdominal { get; set; }


        public int Gastroparesia { get; set; }


        public int Disfagia { get; set; }


        public int Refluxo_GastroEsfagico { get; set; }


        public int Distensao_Abdominal { get; set; }


        public int Vomito { get; set; }


        public int Vomito_Vezes_Dia { get; set; }


        public string Observacao_Intercorrencia_Gastrica { get; set; }


        public string Prescricao_Hidrica { get; set; }


        public string Mucosa { get; set; }


        public string Abdomen { get; set; }


        public string Eliminacao { get; set; }


        public string Lesao_Tegumentar { get; set; }


        public string Gordura_Subcutanea { get; set; }


        public string Edema { get; set; }


        public string Palpacao { get; set; }


        public string Palpacao_Vezes_Dia { get; set; }


        public string Observacao_Exame_Fisico { get; set; }


        public string Peso_Atual { get; set; }


        public string Peso_Situacao { get; set; }


        public string Altura { get; set; }


        public string Altura_Situacao { get; set; }


        public string Peso_Habitual { get; set; }


        public string Indice_Massa_Corporal { get; set; }


        public string Perca_Peso_6_Meses { get; set; }


        public string Percentual_Perca_Peso { get; set; }


        public string Classificacao_Nutricional { get; set; }


        public string Observacao_Avaliacao_Nutricional { get; set; }


        public string Curva_Crecimento_Avaliacao_Nutricional { get; set; }


        public string Circunferencia_Braco_Valor_Medido { get; set; }


        public string Circunferencia_Braco_Percentil_Adequacao { get; set; }


        public string Valor_Calorico_Kcal { get; set; }


        public string Dobra_Cutanea_Tricipal_Valor_Medido { get; set; }


        public string Dobra_Cutanea_Tricipal_Percentil_Adequacao { get; set; }


        public string Circunferencia_Muscular_Braco_Valor_Medido { get; set; }


        public string Circunferencia_Muscular_Braco_Percentil_Adequacao { get; set; }


        public string Circunferencia_Panturrilha_Valor_Medido { get; set; }


        public string Circunferencia_Panturrilha_Percentil_Adequacao { get; set; }


        public string Area_Muscular_Braco_Valor_Medio { get; set; }


        public string Area_Muscular_Braco_Percentil_Adequacao { get; set; }


        public string Dobra_Cultanea_Biceps_Valor_Medido { get; set; }


        public string Dobra_Cultanea_Biceps_Percentil_Adequacao { get; set; }


        public string Dobra_Cultanea_Subscapular_Valor_Medido { get; set; }


        public string Dobra_Cultanea_Subscapular_Percentil_Adequacao { get; set; }


        public string Altura_Joelho_Valor_Medido { get; set; }


        public string Altura_Joelho_Percentil_Adequacao { get; set; }


        public string Circunferencia_Cintura_Valor_Medido { get; set; }


        public string Circunferencia_Cintura_Percentil_Adequacao { get; set; }


        public string Circunferencia_Quadril_Valor_Medido { get; set; }


        public string Circunferencia_Quadril_Percentil_Adequacao { get; set; }


        public string Valor_Calorico_Glic { get; set; }


        public string Valor_Calorico_Kcal_Kg { get; set; }


        public string VAlor_Lip { get; set; }


        public string Valor_PTN { get; set; }


        public string Valor_PTN_KG { get; set; }


        public int Anamnese_Alimentar_Alergia { get; set; }


        public int Anamnese_Alimentar_Intolerancia { get; set; }


        public int Anamnese_Alimentar_Restricao_Hidrica { get; set; }


        public string Net { get; set; }


        public string Apresentacao_Embalagem { get; set; }


        public string Horario_Administracao { get; set; }


        public string Bomba_Infusao { get; set; }


        public string Velocidade { get; set; }


        public string Planejamento_Mensal { get; set; }


        public string Planejamento_Quinzenal { get; set; }


        public string Planejamento_Bimestral_Par { get; set; }


        public string Planejamento_Bimestral { get; set; }


        public string Impar { get; set; }


        public string Trimestral { get; set; }

        public string Alta_Nutricional { get; set; }


        public string Aspectos_Sociais { get; set; }


        public string Programacao { get; set; }


        public int Objetivo_Manutencao { get; set; }

        public int Objetivo_Melhorar { get; set; }

        public int Objetivo_Evitar { get; set; }

        public int Objetivo_Favorecer { get; set; }

        public string Condulta { get; set; }

        public string usuario_inclusao { get; set; }

        public DateTime data_inclusao { get; set; }

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
