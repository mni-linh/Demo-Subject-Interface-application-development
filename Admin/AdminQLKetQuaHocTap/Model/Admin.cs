namespace AdminQLKetQuaHocTap
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        [StringLength(100)]
        public string username { get; set; }

        [StringLength(100)]
        public string password { get; set; }

        public bool? status { get; set; }
    }
}
