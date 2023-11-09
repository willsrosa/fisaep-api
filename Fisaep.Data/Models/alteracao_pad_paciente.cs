namespace Fisaep.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class alteracao_pad_paciente
    {
        public int Id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string c_descricao { get; set; }

        public int id_paciente { get; set; }

        public virtual Cadastro_Pacientes Cadastro_Pacientes { get; set; }
    }
}
