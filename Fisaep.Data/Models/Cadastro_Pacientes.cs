namespace Fisaep.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Cadastro_Pacientes
    {

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string c_nome { get; set; }

        public DateTime? dt_nascimento { get; set; }

        [StringLength(20)]
        public string c_cpf { get; set; }

        //[Required]
        [StringLength(20)]
        public string c_rg { get; set; }

        public int? id_sexo { get; set; }

        [StringLength(200)]
        public string c_nome_cuidador { get; set; }

        public int? n_status { get; set; }

        public DateTime? d_bloqueio { get; set; }

        public DateTime? data_inclusao { get; set; }

        public DateTime? data_exclusao { get; set; }

        [StringLength(128)]
        public string usuario_inclusao { get; set; }

        [StringLength(128)]
        public string usuario_exclusao { get; set; }

        public int? IdCene { get; set; }

    }
}
