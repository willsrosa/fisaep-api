namespace Fisaep.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Especialista_Cidades_Atendidas
    {
        public int Id { get; set; }

        public int Id_Cidade { get; set; }

        public int id_especialista { get; set; }

        public DateTime? data_inclusao { get; set; }

        public DateTime? data_exclusao { get; set; }

        [StringLength(128)]
        public string usuario_inclusao { get; set; }

        [StringLength(128)]
        public string usuario_exclusao { get; set; }

        public string latitude { get; set; }

        public string longitude { get; set; }

        public virtual Cadastro_Especialista Cadastro_Especialista { get; set; }

        public virtual Cidades Cidades { get; set; }
    }
}
