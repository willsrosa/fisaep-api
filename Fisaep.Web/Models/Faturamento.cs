using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fisaep.Web.Models
{
    public class faturamentomensal
    {
        public string mes_faturamento { get; set; }

        public string Correios { get; set; }

        public string Desconto { get; set; }
        public string Total { get; set; }

        public IList<FaturamentoViewModel> FaturamentoViewModel { get; set; }
        public IList<FaturamentoExtraViewModel> FaturamentoExtraViewModel { get; set; }
        public IList<FaturamentoCorreiosViewModel> FaturamentoCorreiosViewModel { get; set; }
    }


    public class FaturamentoViewModel
    {

        public string Paciente { get; set; }


        public string Mes_Referencia { get; set; }
        public string ValorTotal { get; set; }
        public decimal ValorDecimal { get; set; }
    }

    public class FaturamentoExtraViewModel
    {
        public string Descricao { get; set; }

        public string MesReferencia { get; set; }

        public string Valor { get; set; }
        public decimal ValorDecimal { get; set; }


    }

    public class FaturamentoCorreiosViewModel
    {

        public string MesReferencia { get; set; }

        public string Valor { get; set; }
        public decimal ValorDecimal { get; set; }


    }

}
