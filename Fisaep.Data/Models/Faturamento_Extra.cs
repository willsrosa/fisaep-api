using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
   public partial class Faturamento_Extra
    {
        public int? Id { get; set; }
        public int? Paciente { get; set; }
        public int Especialista { get; set; }
        public string DataRef { get; set; }
        public string MesPagto { get; set; }
        public decimal? Valor { get; set; }
        public string Observacao { get; set; }
        public DateTime? DataAutorizacao { get; set; }
        public string UsuarioAutorizacao { get; set; }
        public DateTime? DataNegativa { get; set; }
        public string UsuarioNegativa { get; set; }
        public DateTime? DataHora { get; set; }
        public DateTime? data_exclusao { get; set; }
        public string usuario_exclusao { get; set; }
        public string motivo_exclusao { get; set; }
    }
}
