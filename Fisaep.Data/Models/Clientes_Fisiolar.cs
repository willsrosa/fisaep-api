namespace Fisaep.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Clientes_Fisiolar
    {


        public int Id { get; set; }

        [StringLength(50)]
        public string razao_social { get; set; }

        [StringLength(50)]
        public string nome_fantasia { get; set; }

        [StringLength(20)]
        public string c_cnpj { get; set; }

        [StringLength(100)]
        public string c_logradouro { get; set; }

        [StringLength(30)]
        public string c_responsavel { get; set; }

        public DateTime? data_inclusao { get; set; }

        public DateTime? data_exclusao { get; set; }

        [StringLength(128)]
        public string usuario_inclusao { get; set; }

        [StringLength(128)]
        public string usuario_exclusao { get; set; }

        [StringLength(20)]
        public string c_telefone { get; set; }

        public int? tipo_evolutiva { get; set; }

        public int? n_tipo_avaliacao { get; set; }

      
    }
}
