using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
    [Table("Clientes_Valores_Padrao")]
    public partial class Clientes_Valores_Padrao
    {
        public int Id { get; set; }

        public int Cliente { get; set; }

        public int Especialidade { get; set; }

        public decimal Valor { get; set; }

        public DateTime?data_inclusao { get; set; }

        public string usuario_inclusao { get; set; }

        public DateTime? data_exclusao { get; set; }

        public string usuario_exclusao { get; set; }


    }
}
