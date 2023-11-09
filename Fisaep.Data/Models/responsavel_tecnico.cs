namespace Fisaep.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class responsavel_tecnico
    {
 
        public int Id { get; set; }

        public int id_responsavel_tecnico { get; set; }

        [Required]
        [StringLength(30)]
        public string c_codigo_responsavel_tecnico { get; set; }

        [Required]
        [StringLength(30)]
        public string c_senha_responsavel { get; set; }

        public int id_servico_integracao { get; set; }

        public DateTime? data_inclusao { get; set; }

        public DateTime? data_exclusao { get; set; }

        [StringLength(128)]
        public string usuario_inclusao { get; set; }

        [StringLength(128)]
        public string usuario_exclusao { get; set; }
 
    }
}
