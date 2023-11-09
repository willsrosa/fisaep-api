using System;
using System.Collections.Generic;
using System.Text;

namespace Fisaep.Data
{
   public partial class falta_especialista
    {
        public int id { get; set; }
        public int id_paciente { get; set; }
        public int id_especialista { get; set; }
        public DateTime data_falta { get; set; }
        public string motivo_falta { get; set; }
        public DateTime data_inclusao { get; set; }
        public string usuario_inclusao { get; set; }
    }
}
