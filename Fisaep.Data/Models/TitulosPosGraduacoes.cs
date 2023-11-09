using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
    public partial class TitulosPosGraduacoes
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public int Aluno { get; set; }
        public DateTime Data { get; set; }
        public decimal Desconto { get; set; }
        public int Lote { get; set; }
        public string UsuarioExclusao { get; set; }
        public string Usuario { get; set; }
        public DateTime? DataHora { get; set; }
        public DateTime? DataExclusao { get; set; }
        public DateTime? DataBaixa { get; set; }
    }
}
