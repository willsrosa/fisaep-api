using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fisaep.Web.Models
{
    public class Pacientes
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Convenio { get; set; }

        public string tipo_avaliacao { get; set; }
    }

    public class pacientesMeses {
        public int PacienteId { get; set; }

        public string Nome { get; set; }
        public IList<string> Meses { get; set; }
    }
    public partial class EvolucaoPacienteTxtViewModel
    {
        public DateTime? dataevolutivo { get; set; }
        public int id_paciente { get; set; }
        public string texto { get; set; }
        public string imagem_url { get; set; }
        public string mesesevolutivo { get; set; }
    }

    public partial class inserirFichaViewModel
    {
        public string imagem_url { get; set; }
        public string mes { get; set; }
        public string texto { get; set; }
        public int id_paciente { get; set; }
        public string atendimentos { get; set; }
    }


    public partial class listarevolutivosviewmodel {
        public string texto { get; set; }
        public string imagem_url { get; set; }
        public string data { get; set; }

    }
    public partial class listarfichas
    {
        public string texto { get; set; }
        public string imagem_url { get; set; }
        public string atendimentos { get; set; }

    }




    public partial class checkinviewmodel {
        public DateTime dataevolutivo { get; set; }
        public int id_paciente { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string endereco { get; set; }
    }

    public partial class DeviceVieoModel
    {
        public string tokennotification { get; set; }
        public string acesso { get; set; }
    }
    public partial class faltaviewmodel
    {

        public int id { get; set; }
        public int id_paciente { get; set; }
        public int id_especialista { get; set; }
        public DateTime data_falta { get; set; }
        public string motivo_falta { get; set; }
        public DateTime data_inclusao { get; set; }
        public string usuario_inclusao { get; set; }
    }


    public partial class getfaltas
    {
        public string paciente { get; set; }
        public DateTime datafalta { get; set; }
        public string motivo { get; set; }
    }


    public class especialistaEndereco {
        public string cep { get; set; }
        public string endereco { get; set; }
        public string complemento { get; set; }
        public int id { get; set; }
    }


}
