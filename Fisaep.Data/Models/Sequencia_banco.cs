using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
   public partial class Sequencia_banco
    {
        public int Id { get; set; }
        public int codigo_remessa { get; set; }
        public DateTime data_geracao { get; set; }
        public string conteudo { get; set; }

    }
}
