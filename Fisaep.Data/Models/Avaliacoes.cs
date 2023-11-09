using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Fisaep.Data.Models
{
    [Table("Avaliacoes")]
    public partial  class Avaliacoes
    {
        public int Id { get; set; }
        public DateTime? data_envio { get; set; }
        public DateTime? d_data { get; set; }
         public string url_imagem { get; set; }
        public string url_imagem2 { get; set; }
        public string url_imagem3 { get; set; }
        public string url_imagem4 { get; set; }
        public string url_imagem5 { get; set; }
        public string ConteudoTxt { get; set; }
        public string ConteudoTxt_2 { get; set; }
        public string avaliacao_prorrogacao { get; set; }
        public int id_paciente { get; set; }
        public int id_especialista { get; set; }
        public DateTime? DataNegativa { get; set; }
        public DateTime? DataAutorizacao { get; set; }
        public DateTime? data_inclusao { get; set; }
        public string UsuarioNegativa { get; set; }
        public string UsuarioAutorizacao { get; set; }
        public int? especialidade { get; set; }
        public string usuario_inclusao { get; set; }

    }
}
