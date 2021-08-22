namespace AdminQLKetQuaHocTap
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Study_result
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string id_subject { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string id_student { get; set; }

        public double attendance { get; set; }

        public double midterm_score { get; set; }

        public double endterm_score { get; set; }

        public double average_score { get; set; }

        public virtual Student Student { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
