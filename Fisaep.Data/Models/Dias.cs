namespace Fisaep.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Dias
    {
 
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Descricao { get; set; }

        [StringLength(128)]
        public string usuario_exclusao { get; set; }

        public DateTime? data_inclusao { get; set; }

        public DateTime? data_exclusao { get; set; }

        [StringLength(128)]
        public string usuario_inclusao { get; set; }
 
    }
}
