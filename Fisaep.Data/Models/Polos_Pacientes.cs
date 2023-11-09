using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
   public partial class Polos_Pacientes
    {
        public int Id { get; set; }
        public int? CodigoPolo { get; set; }
        public string Descricao { get; set; }
        public int ClienteId { get; set; }
    }
}
