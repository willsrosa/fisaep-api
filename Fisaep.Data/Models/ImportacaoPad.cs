using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
    [Table("ImportacaoPad")]
    public partial class ImportacaoPad
    {
        public int Id { get; set; }
        public int Pad { get; set; }
        public string AchouPrograma { get; set; }
        public string Paciente { get; set; }
        public string AchouPaciente { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
    }
}
