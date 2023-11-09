namespace Fisaep.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Especialista_Paciente
    {
         public int Id { get; set; }

        public int Id_paciente { get; set; }

        public int id_especialista { get; set; }

        public int? n_permissao_especialista { get; set; }

        public decimal v_valor_sessao { get; set; }

        public decimal? v_valor_sessao_fds { get; set; }

        public DateTime? data_inclusao { get; set; }

        public DateTime? data_exclusao { get; set; }

        [StringLength(128)]
        public string usuario_inclusao { get; set; }

        [StringLength(128)]
        public string usuario_exclusao { get; set; }

        //public virtual Cadastro_Especialista Cadastro_Especialista { get; set; }

        //public virtual Cadastro_Pacientes Cadastro_Pacientes { get; set; }

        //public virtual Especialista_Paciente_Permissao Especialista_Paciente_Permissao { get; set; }

        public decimal? v_valor_recebido { get; set; }
    }
}
