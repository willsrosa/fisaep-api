using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisaep.Data
{
    [Table("Geolocalizacao")]
    public partial class Geolocalizacao
    {
        public int Id { get; set; }
        public string UsuarioId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime DataLogin { get; set; }
    }
}
