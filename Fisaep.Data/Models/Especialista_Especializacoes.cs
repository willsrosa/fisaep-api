namespace Fisaep.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Especialista_Especializacoes
    {
        public int Id { get; set; }

        public int n_nivel { get; set; }

        [Required]
        [StringLength(250)]
        public string c_curso { get; set; }

        [Required]
        [StringLength(250)]
        public string c_instituicao { get; set; }

        public int id_cidade { get; set; }

        public int? n_ano_inicio { get; set; }

        public int? n_ano_conclusao { get; set; }

        public int? n_concluiu { get; set; }

        public int id_especialista { get; set; }

        public DateTime? data_inclusao { get; set; }

        public DateTime? data_exclusao { get; set; }

        [StringLength(128)]
        public string usuario_inclusao { get; set; }

        [StringLength(128)]
        public string usuario_exclusao { get; set; }

        public virtual Cadastro_Especialista Cadastro_Especialista { get; set; }

        public virtual Nivel_Escolaridade Nivel_Escolaridade { get; set; }
    }
}
