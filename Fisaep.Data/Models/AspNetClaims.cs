namespace Fisaep.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class AspNetClaims
    { 
        public Guid Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }
    }
}
