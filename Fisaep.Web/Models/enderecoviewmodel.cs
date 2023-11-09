using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fisaep.Web.Models
{
    public class enderecoviewmodel
    {
        public int Id { get; set; }

        public string c_cep { get; set; }

        public string c_logradouro { get; set; }

        public string c_complemento { get; set; }

        public int id_especialista { get; set; }

        public string latitude { get; set; }

        public string longitude { get; set; }
    }
}
