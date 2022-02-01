namespace MED_FAC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblDept")]
    public partial class tblDept
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblDept()
        {
            tblDoctors = new HashSet<tblDoctor>();
        }

        [Key]
        public int DEPARTMENT_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string DEPARTMENT_NAME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDoctor> tblDoctors { get; set; }
    }
}
