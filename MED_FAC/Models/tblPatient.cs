namespace MED_FAC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblPatient")]
    public partial class tblPatient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPatient()
        {
            tblApps = new HashSet<tblApp>();
            tblFeedbacks = new HashSet<tblFeedback>();
            tblOrders = new HashSet<tblOrder>();
        }

        [Key]
        public int PATIENT_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string PATIENT_NAME { get; set; }

        [Required]
        public string PATIENT_ADDRESS { get; set; }

        public string PATIENT_EMAIL { get; set; }

        [Required]
        [StringLength(50)]
        public string PATIENT_CONTACT { get; set; }

        [StringLength(50)]
        public string PATIENT_CNIC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblApp> tblApps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblFeedback> tblFeedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOrder> tblOrders { get; set; }
    }
}
