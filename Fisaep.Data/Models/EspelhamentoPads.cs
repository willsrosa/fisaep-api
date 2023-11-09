using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
    public partial class EspelhamentoPads
    {
        public int Id { get; set; }
        public int Paciente { get; set; }
        public int Especialidade { get; set; }
        public DateTime? Data { get; set; }
        public string Motivo { get; set; }
        public int? EspecialistaFalta { get; set; }
        public string UsuarioInclusao { get; set; }
        public string UsuarioExclusao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public DateTime? DataInclusao { get; set; }
        public int Status { get; set; }
        public int? QtdeAtendimentos { get; set; }
        public int? QtdeAtendimentosFalta { get; set; }
    }
}
