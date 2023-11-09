using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fisaep.Web.Models
{
    public class UsuarioAutenticacao
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }

    public class DadosUsuario
    {
        public string Id { get; set; }
        public string Nome { get; set; }

        public string especialidade { get; set; }
    }
    public class DadosUsuarioLogin
    {
        public string email { get; set; }
    }


    public class confirmamensagem {
        public int id { get; set; }
        public string tipo { get; set; }
    }
}
