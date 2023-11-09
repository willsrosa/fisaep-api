namespace Fisaep.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Especialidades
    {
         public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string c_descricao { get; set; }

        public string c_descricao_abreviada { get; set; }
        public int? id_responsavel_tecnico { get; set; }

        public DateTime? data_inclusao { get; set; }

        public DateTime? data_exclusao { get; set; }

        [StringLength(128)]
        public string usuario_inclusao { get; set; }

        [StringLength(128)]
        public string usuario_exclusao { get; set; }
 
    }
}
