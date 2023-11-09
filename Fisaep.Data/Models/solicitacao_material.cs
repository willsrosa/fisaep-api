namespace Fisaep.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class solicitacao_material
    {
        [Key]
        public int id { get; set; }

        public int? id_paciente { get; set; }

        [Column(TypeName = "text")]
        public string c_historico_clinico { get; set; }

        [Column(TypeName = "text")]
        public string c_materiais { get; set; }

        public int id_especialista { get; set; }

        public DateTime? DataAutorizacao { get; set; }
        public DateTime? DataNegativa { get; set; }
        public string UsuarioAutorizacao { get; set; }
        public string UsuarioNegativa { get; set; }
    }
}
