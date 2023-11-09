namespace Fisaep.Data
{
    using System.ComponentModel.DataAnnotations;

    public partial class produtividade_mensal_paciente
    {
        public int Id { get; set; }

        [Required]
        [StringLength(7)]
        public string c_periodo { get; set; }

        public int n_atendimentos_imagem { get; set; }

        public int c_observacao { get; set; }

        [Required]
        [StringLength(300)]
        public string c_caminho_imagem { get; set; }

        public int id_paciente { get; set; }

        public virtual Cadastro_Pacientes Cadastro_Pacientes { get; set; }
    }
}
