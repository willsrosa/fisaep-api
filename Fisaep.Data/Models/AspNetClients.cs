namespace Fisaep.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class AspNetClients
    {
        public int Id { get; set; }

        public string ClientKey { get; set; }

        [StringLength(128)]
        public string ApplicationUser_Id { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
