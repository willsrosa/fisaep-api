using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
   public partial class pgto_pendentes
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public int Profissional { get; set; }
        public int Paciente { get; set; }
        public string Periodo { get; set; }
    }
}
