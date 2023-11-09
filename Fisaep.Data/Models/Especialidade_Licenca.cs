using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
    [Table("Especialidade_Licenca")]
    public partial class Especialidade_Licenca
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int EspecialidadeId { get; set; }
    }
}
