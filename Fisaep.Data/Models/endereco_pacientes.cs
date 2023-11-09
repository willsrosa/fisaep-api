namespace Fisaep.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class endereco_pacientes
    {
        public int Id { get; set; }

        [Required]
        [StringLength(12)]
        public string c_cep { get; set; }

        [StringLength(250)]
        public string c_logradouro { get; set; }

        [StringLength(150)]
        public string c_complemento { get; set; }

        public int id_paciente { get; set; }

        public DateTime? data_inclusao { get; set; }

        public DateTime? data_exclusao { get; set; }

        [StringLength(128)]
        public string usuario_inclusao { get; set; }

        [StringLength(128)]
        public string usuario_exclusao { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public virtual Cadastro_Pacientes Cadastro_Pacientes { get; set; }
    }
}
