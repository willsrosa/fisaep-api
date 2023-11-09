namespace Fisaep.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Contas_Bancaria
    {
        public int Id { get; set; }

        public int n_tipo_pessoa { get; set; }

        [Required]
        [StringLength(18)]
        public string c_cpf_cnpj { get; set; }

        [Required]
        [StringLength(100)]
        public string c_titular { get; set; }

        [Required]
        [StringLength(50)]
        public string c_banco { get; set; }

        public int n_agencia { get; set; }

        public int? n_digito_agencia { get; set; }

        public long n_conta { get; set; }

        public int? n_digito_conta { get; set; }

        [StringLength(250)]
        public string c_observacao { get; set; }

        public int? id_especialista { get; set; }

        public DateTime? data_inclusao { get; set; }

        public DateTime? data_exclusao { get; set; }

        [StringLength(128)]
        public string usuario_inclusao { get; set; }

        [StringLength(128)]
        public string usuario_exclusao { get; set; }

    }
}
