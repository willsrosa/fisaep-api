using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
    public partial class Pacientes_Valores
    {
        public int Id { get; set; }
        public int Paciente { get; set; }
        public int Especialidade { get; set; }
        public decimal Valor { get; set; }
        public DateTime? Data_inclusao { get; set; }
        public DateTime? usuario_inclusao { get; set; }
        public DateTime? Data_exclusao { get; set; }
        public string usuario_exclusao { get; set; }
    }
}
