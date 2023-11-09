namespace Fisaep.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Grupo_Usuario_Permissao
    {
        public int Id { get; set; }

        public int id_menu { get; set; }

        public int id_grupo { get; set; }

        public DateTime? data_inclusao { get; set; }

        public DateTime? data_exclusao { get; set; }

        [StringLength(128)]
        public string usuario_inclusao { get; set; }

        [StringLength(128)]
        public string usuario_exclusao { get; set; }

        public virtual Grupo_Usuario Grupo_Usuario { get; set; }

        public virtual Menu Menu { get; set; }
    }
}
