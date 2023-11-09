namespace Fisaep.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Alteracao_Pad
    {
        [Key]
        public int id { get; set; }

        public int? paciente { get; set; }

        [StringLength(200)]
        public string justificativa { get; set; }

        public int id_especialista { get; set; }

        public DateTime? DataAutorizacao { get; set; }
        public DateTime? DataNegativa { get; set; }
        public string UsuarioAutorizacao { get; set; }
        public string UsuarioNegativa { get; set; }
    }
}
