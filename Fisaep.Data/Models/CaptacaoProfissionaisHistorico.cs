using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
    [Table("CaptacaoProfissionaisHistorico")]
    public partial  class CaptacaoProfissionaisHistorico
    {
        public int Id { get; set; }
        public DateTime? DataContato { get; set; }
        public string Status { get; set; }
        public string Historico { get; set; }
        public int id_captacao { get; set; }
        public string usuario_inclusao { get; set; }
    }
}
