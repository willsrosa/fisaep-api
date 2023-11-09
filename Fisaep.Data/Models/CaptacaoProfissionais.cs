using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
  public partial class CaptacaoProfissionais
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Especialidade { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public int? Verificado { get; set; }
        public DateTime? Data { get; set; }
    }
}
