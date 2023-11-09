using System;
using System.Collections.Generic;
using System.Text;

namespace Fisaep.Data
{
   public partial class MensagensApp
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public int id_especialista { get; set; }
        public DateTime? data_leitura { get; set; }
        public string usuario_inclusao { get; set; }
        public DateTime? data_inclusao { get; set; }

        public string finalizada_sn { get; set; }
        public string avaliacao_sn { get; set; }
        public string lote { get; set; }
        public DateTime? data_exclusao { get; set; }
    }
}
