namespace Fisaep.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class solicitacao_material_paciente
    {
        public int Id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string c_historico_clinico { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string c_materiais { get; set; }

        public int? id_paciente { get; set; }

        public virtual Cadastro_Pacientes Cadastro_Pacientes { get; set; }
    }
}
