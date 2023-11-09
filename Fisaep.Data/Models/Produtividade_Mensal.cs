namespace Fisaep.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Produtividade_Mensal
    {
        [Key]
        public int id { get; set; }


        public int paciente { get; set; }


        public string periodo { get; set; }

        [StringLength(200)]
        public string atendimentos_dentro_imagem { get; set; }

        [StringLength(200)]
        public string observacao { get; set; }

        [StringLength(300)]
        public string url_imagem { get; set; }

        public string url_google { get; set; }


        public int id_especialista { get; set; }

        public string usuario_inclusao { get; set; }

        public DateTime data_inclusao { get; set; }

        public int? id_especialidade { get; set; }
    }
}
