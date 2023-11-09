using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
    [Table("PagamentosAvulso")]
    public partial class PagamentosAvulso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int? Banco { get; set; }
        public int? Agencia { get; set; }
        public int? digitoAgencia { get; set; }
        public int? Conta { get; set; }
        public int? digitoConta { get; set; }
        public string CPF { get; set; }
        public int? PacienteId { get; set; }
        public DateTime? DataPagamento { get; set; }
    }
}
