namespace PhatTrienUngDungGiaoDien
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Teacher")]
    public partial class Teacher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Teacher()
        {
            Assignments = new HashSet<Assignment>();
        }

        [StringLength(10)]
        public string id { get; set; }

        [Required]
        [StringLength(100)]
        public string password { get; set; }

        [Required]
        [StringLength(100)]
        public string fullname { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_of_birth { get; set; }

        [Required]
        [StringLength(250)]
        public string address { get; set; }

        [Column(TypeName = "date")]
        public DateTime day_start { get; set; }

        [Required]
        [StringLength(10)]
        public string id_faculty { get; set; }

        public bool status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assignment> Assignments { get; set; }

        public virtual Faculty Faculty { get; set; }
    }
}
