namespace Fisaep.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SimNao")]
    public partial class SimNao
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string c_descricao { get; set; }

        public DateTime? data_inclusao { get; set; }

        public DateTime? data_exclusao { get; set; }

        [StringLength(128)]
        public string usuario_inclusao { get; set; }

        [StringLength(128)]
        public string usuario_exclusao { get; set; }
    }
}
