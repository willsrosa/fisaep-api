namespace Fisaep.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Cadastro_Historico_Pacientes
    {
        public int Id { get; set; }

        public DateTime d_admissao { get; set; }

        public DateTime? d_termino { get; set; }

        public int id_clientes { get; set; }

        public int? id_polo { get; set; }

        [StringLength(50)]
        public string c_carteirinha { get; set; }

        [StringLength(500)]
        public string c_diagnostico { get; set; }

        public int n_status { get; set; }

        public int id_paciente { get; set; }

        public DateTime? data_inclusao { get; set; }

        public DateTime? data_exclusao { get; set; }

        [StringLength(128)]
        public string usuario_inclusao { get; set; }

        [StringLength(128)]
        public string usuario_exclusao { get; set; }

        public int? id_syscare { get; set; }


    }
}
