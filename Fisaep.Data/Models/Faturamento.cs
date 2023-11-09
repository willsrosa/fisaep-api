using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
    [Table("Faturamento")]
    public partial class Faturamento
    {
        public int id { get; set; }
        public int id_paciente { get; set; }
        public int id_especialista { get; set; }
        public string mes_referencia { get; set; }
        public int? fichas { get; set; }
        public int? copias { get; set; }
        public int? evolutivas { get; set; }
        public int?  avaliacao { get; set; }
        public decimal? valor_pagto { get; set; }
        public decimal? Correios { get; set; }

        public DateTime? data_autorizacao { get; set; }
        public DateTime? data_negacao { get; set; }
        public DateTime? data_pagamento { get; set; }
        public DateTime? enviado_banco { get; set; }
        public DateTime? dataHora { get; set; }
        public string Usuario { get; set; }
        public string MesPagto { get; set; }

        public DateTime? data_exclusao { get; set; }
        public string usuario_exclusao { get; set; }
        public string motivo_exclusao { get; set; }
    }
}
