namespace Fisaep.Data
{
    using System.ComponentModel.DataAnnotations;

    public partial class Status_Historico_Pacientes
    {
        public int Id { get; set; }

        [StringLength(150)]
        public string c_descricao { get; set; }
    }
}
