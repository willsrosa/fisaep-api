using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
    public partial class Evolutiva_Simples
    {
        public int Id { get; set; }
        public int Id_Paciente { get; set; }
        public int Id_Profissional { get; set; }
        public string hora_inicio { get; set; }
        public string hora_termino { get; set; }
        public DateTime d_data { get; set; }
        public string usuario_inclusao { get; set; }
        public DateTime data_inclusao { get; set; }
    }
}
