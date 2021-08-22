namespace PhatTrienUngDungGiaoDien
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Subject")]
    public partial class Subject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subject()
        {
            Assignments = new HashSet<Assignment>();
            Study_result = new HashSet<Study_result>();
        }

        [StringLength(10)]
        public string id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        public int course_credit { get; set; }

        public int semester { get; set; }

        [Required]
        [StringLength(10)]
        public string id_subject_type { get; set; }

        [Required]
        [StringLength(10)]
        public string id_faculty { get; set; }

        public bool status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assignment> Assignments { get; set; }

        public virtual Faculty Faculty { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Study_result> Study_result { get; set; }

        public virtual Subject_type Subject_type { get; set; }
    }
}
