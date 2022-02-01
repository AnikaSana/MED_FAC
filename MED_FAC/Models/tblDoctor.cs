namespace MED_FAC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblDoctor")]
    public partial class tblDoctor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblDoctor()
        {
            tblSchedules = new HashSet<tblSchedule>();
        }

        [Key]
        public int DOCTOR_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string DOCTOR_NAME { get; set; }

        //[Required]
        public string DOCTOR_IMAGE { get; set; }

        [Required]
        [StringLength(50)]
        public string DOCTOR_FEE { get; set; }

        [Required]
        [StringLength(50)]
        public string DOCTOR_CONTACT { get; set; }

        public int DEPARTMENT_FID { get; set; }

        public virtual tblDept tblDept { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSchedule> tblSchedules { get; set; }
    }
}
