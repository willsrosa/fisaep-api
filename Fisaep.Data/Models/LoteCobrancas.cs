using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
    public partial class LoteCobrancas
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Periodo { get; set; }
        public string UsuarioExclusao { get; set; }
        public string Usuario { get; set; }
        public DateTime? DataHora { get; set; }
        public DateTime DataExclusao { get; set; }
    }
}
