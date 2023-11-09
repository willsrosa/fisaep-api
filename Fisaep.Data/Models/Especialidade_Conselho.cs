using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
    [Table("Especialidade_Conselho")]
    public partial class Especialidade_Conselho
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int EspecialidadeId { get; set; }
    }
}
