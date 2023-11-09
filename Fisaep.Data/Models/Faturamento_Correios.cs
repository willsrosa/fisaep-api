using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
   public partial class Faturamento_Correios
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public int EspecialistaId { get; set; }
        public string DataRef { get; set; }
        public string MesPagto { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataHora { get; set; }
        public DateTime? data_exclusao { get; set; }
        public string usuario_exclusao { get; set; }
        public string motivo_exclusao { get; set; }
        public string usuario_inclusao { get; set; }
    }
}
