using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
    public partial class CadastroAlunos
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public decimal Valor { get; set; }

        public decimal DescontoPagamentoAntecipado { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Complemento { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }

        public string Cep { get; set; }

        public string CPF { get; set; }

        public string RG { get; set; }


        public string UsuarioExclusao { get; set; }
        public string Usuario { get; set; }
        public DateTime? DataHora { get; set; }
        public DateTime? DataExclusao { get; set; }


    }



}
