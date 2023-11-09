namespace Fisaep.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Programa_Sugestao_Dias
    {
        public int Id { get; set; }

        public int id_programa { get; set; }

        public int? id_dia { get; set; }

        public int? atendimentos_dia { get; set; }

        public DateTime? data_inclusao { get; set; }

        public DateTime? data_exclusao { get; set; }

        [StringLength(128)]
        public string usuario_inclusao { get; set; }

        [StringLength(128)]
        public string usuario_exclusao { get; set; }
 
    }
}
