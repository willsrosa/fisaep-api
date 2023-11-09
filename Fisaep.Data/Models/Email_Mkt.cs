using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
   public partial class Email_Mkt
    {
        public int Id { get; set; }
        public int Campanha { get; set; }
        public string Email { get; set; }
        public string Exception { get; set; }
        public string Resposta { get; set; }
        public DateTime DataEnvio { get; set; }
        public string Baixado { get; set; }
    }
}
