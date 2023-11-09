using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
  public partial  class NaoDescontarDocs
    {
        public int Id { get; set; }
        public int? usuario_inclusao { get; set; }
        public DateTime? data_inclusao { get; set; }
        public int? id_especialista { get; set; }
        public DateTime? data_exclusao { get; set; }
        public int? usuario_exclusao { get; set; }
    }
}
