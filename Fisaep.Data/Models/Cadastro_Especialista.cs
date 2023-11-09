namespace Fisaep.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Cadastro_Especialista
    {

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string c_nome { get; set; }

        public DateTime? d_nascimento { get; set; }

        [StringLength(14)]
        public string c_cpf { get; set; }

        [StringLength(20)]
        public string c_rg { get; set; }

        public int? id_sexo { get; set; }

        public int? id_estado_civil { get; set; }

        public int? n_filhos { get; set; }

        public int? n_transporte { get; set; }

        public int? id_area_atuacao { get; set; }

        public DateTime? data_inclusao { get; set; }

        public DateTime? data_exclusao { get; set; }

        [StringLength(128)]
        public string usuario_inclusao { get; set; }

        [StringLength(128)]
        public string usuario_exclusao { get; set; }

        public int n_status { get; set; }

        public int grupo_usuario { get; set; }

        [Required]
        [StringLength(128)]
        public string id_usuario { get; set; }

        [Required]
        [StringLength(50)]
        public string c_email_principal { get; set; }

        [StringLength(200)]
        public string c_carimbo { get; set; }


        public int?  n_conselho_regional { get; set; }

        public string n_registro_regional { get; set; }

        public int? n_licenca { get; set; }

        [StringLength(200)]
        public string c_area_atuacao { get; set; }

        public string token { get; set; }

        public DateTime? data_aceite { get; set; }
        public string ip_aceite { get; set; }

    }
}
