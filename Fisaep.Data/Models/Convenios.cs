using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
    public partial class Convenios
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public int ClienteId { get; set; }

        public int? TipoAvaliacao { get; set; }

        public string usuario_exclusao { get; set; }

        public string usuario_inclusao { get; set; }

        public DateTime? data_exclusao { get; set; }

        public DateTime? data_inclusao { get; set; }

        public int? TipoFicha { get; set; }
    }
}
