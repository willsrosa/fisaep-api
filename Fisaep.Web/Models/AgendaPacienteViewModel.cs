using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fisaep.Web.Models
{
    public class AgendaPacienteViewModel
    {
        public string Especialidade { get; set; }
        public int EspecialidadeId { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
        public string MotivoNaoAtendimento { get; set; }
        public int EvolutivosPreenchidos { get; set; }
        public int? QtdeAtendimentos { get; set; }
        public int? QtdeAtendimentosFalta { get; set; }
        public int Pad { get; set; }
        public int? AtendimentosDia { get; set; }
        public int? Evolutivos { get; set; }
        public string AutorizadoPor { get; set; }
    }

    public class EvolutivosPacientes
    {
        public int Limite { get; set; }
        public int? LimiteDiario { get; set; }
        public int Inseridos { get; set; }
        public DateTime Data { get; set; }

        public string data_formatada { get; set; }
        public int Paciente { get; set; }

        public int checkout { get; set; }

    }
}
