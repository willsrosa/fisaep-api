using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
    [Table("EvolucaoFono")]
    public partial class EvolucaoFono
    {
        [Key]
        public int Id { get; set; }
        public int? Paciente_id { get; set; }
        public int? especialista_id { get; set; }
        public string data_hora_inicio { get; set; }
        public string data_hora_termino { get; set; }
        public string patologia { get; set; }
        public string exame_clinico { get; set; }
        public int? orientacao_espaco { get; set; }
        public int? estado_vigilia { get; set; }
        public int? cooperativo { get; set; }
        public int? contactuante { get; set; }
        public int? compreende_ordens { get; set; }
        public int? segue_instrucoes { get; set; }
        public int? responde_perguntas { get; set; }
        public string conduta_realizada { get; set; }
        public int alimentacao { get; set; }
        public string posicao_paciente_atendimento { get; set; }

    }
}
