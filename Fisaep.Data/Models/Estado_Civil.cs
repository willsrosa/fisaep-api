namespace Fisaep.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Estado_Civil
    {
 
        public int Id { get; set; }

        [StringLength(100)]
        public string c_descricao { get; set; }

        public DateTime? data_inclusao { get; set; }

        public DateTime? data_exclusao { get; set; }

        [StringLength(128)]
        public string usuario_inclusao { get; set; }

        [StringLength(128)]
        public string usuario_exclusao { get; set; }
    }
}