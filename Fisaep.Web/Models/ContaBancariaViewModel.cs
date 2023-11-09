using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fisaep.Web.Models
{
    public class ContaBancariaViewModel
    {

        public int Id { get; set; }

        public int n_tipo_pessoa { get; set; }


        public string c_cpf_cnpj { get; set; }


        public string c_titular { get; set; }


        public string c_banco { get; set; }

        public int n_agencia { get; set; }

        public int? n_digito_agencia { get; set; }

        public long n_conta { get; set; }

        public int? n_digito_conta { get; set; }

        public string c_observacao { get; set; }

        public int? id_especialista { get; set; }

        public DateTime? data_inclusao { get; set; }

        public DateTime? data_exclusao { get; set; }

        public string usuario_inclusao { get; set; }

        public string usuario_exclusao { get; set; }
    }

    public class ContaBancariaVisualizacaoViewModel
    {

        public int Id { get; set; }

        public int n_tipo_pessoa { get; set; }


        public string c_cpf_cnpj { get; set; }


        public string c_titular { get; set; }


        public string c_banco { get; set; }

        public int n_agencia { get; set; }

        public int? n_digito_agencia { get; set; }

        public string n_conta { get; set; }

        public int? n_digito_conta { get; set; }

        public string c_observacao { get; set; }

        public int? id_especialista { get; set; }

        public DateTime? data_inclusao { get; set; }

        public DateTime? data_exclusao { get; set; }

        public string usuario_inclusao { get; set; }

        public string usuario_exclusao { get; set; }
    }
}
