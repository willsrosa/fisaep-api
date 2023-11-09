namespace Fisaep.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Programa")]
    public partial class Programa
    {
 

        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string c_descricao { get; set; }

        //public int n_atendimentos_dias { get; set; }

        public DateTime? data_inclusao { get; set; }

        public DateTime? data_exclusao { get; set; }

        [StringLength(128)]
        public string usuario_inclusao { get; set; }

        [StringLength(128)]
        public string usuario_exclusao { get; set; }

        
    }
}
