namespace MED_FAC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblSchedule")]
    public partial class tblSchedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblSchedule()
        {
            tblApps = new HashSet<tblApp>();
        }

        [Key]
        public int SCHEDULE_ID { get; set; }

        public string SCHEDULE_TIME { get; set; }

        

        [Required]
        [StringLength(50)]
        public string SCHEDULE_DAY { get; set; }

        [Required]
        [StringLength(50)]
        public string SCHEDULE_LOC { get; set; }

        public int DOCTOR_FID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblApp> tblApps { get; set; }

        public virtual tblDoctor tblDoctor { get; set; }
    }
}
