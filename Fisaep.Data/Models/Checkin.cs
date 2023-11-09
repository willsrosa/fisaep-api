using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
    [Table("Checkin")]
    public partial class Checkin
    {
        public int Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public int id_especialista { get; set; }
        public int id_paciente { get; set; }
        public string tipo_operacao { get; set; }
        public DateTime Data { get; set; }

    }
}
