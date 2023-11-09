namespace Fisaep.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class AspNetRoles
    {
        public string Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }
    }
}
