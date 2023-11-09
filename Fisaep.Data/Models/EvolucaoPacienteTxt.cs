using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
    [Table("EvolucaoPacienteTxt")]
    public partial class EvolucaoPacienteTxt
    {
        public int Id { get; set; }
        public int? IdEvolucao { get; set; }
        public string ConteudoTxt { get; set; }
        public string ConteudoTxt_2 { get; set; }
        public DateTime Data { get; set; }
        public string HoraInicio { get; set; }
        public string HoraTermino { get; set; }
        public string usuario_inclusao { get; set; }
        public DateTime data_inclusao { get; set; }
        public string tipo_evolutiva { get; set; }
        public string copia_sn { get; set; }
        public int? Id_Paciente { get; set; }
        public int? Especialidade { get; set; }
        public int? Id_especialista { get; set; }
        public decimal? ValorSessao { get; set; }
        public string imagem_url { get; set; }

        public string tipo { get; set; }
        public string sem_ficha { get; set; }

    }
}
