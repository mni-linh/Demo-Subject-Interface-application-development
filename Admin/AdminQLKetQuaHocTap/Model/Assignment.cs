namespace AdminQLKetQuaHocTap
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Assignment")]
    public partial class Assignment
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string id_subject { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string id_teacher { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int year { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
