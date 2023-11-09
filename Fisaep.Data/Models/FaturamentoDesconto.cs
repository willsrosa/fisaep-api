using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
    [Table("FaturamentoDesconto")]
    public partial class FaturamentoDesconto
    {
        public int Id { get; set; }
        public string DataRef { get; set; }
        public decimal Valor { get; set; }
        public string Observacao { get; set; }
        public int? Paciente { get; set; }
        public int? Especialista { get; set; }
        public DateTime? Data_Pagamento { get; set; }
    }
}
