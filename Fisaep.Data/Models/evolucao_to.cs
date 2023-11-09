using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
   public partial class evolucao_to
    {
        [key]
        public int Id { get; set; }
        public int paciente_id { get; set; }
        public int especialista_id { get; set; }
        public string data_hora_inicio { get; set; }
        public string data_hora_termino { get; set; }
        public string condutas_realizadas { get; set; }
    }
}
