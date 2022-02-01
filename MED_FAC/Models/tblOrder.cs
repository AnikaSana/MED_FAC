namespace MED_FAC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblOrder")]
    public partial class tblOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblOrder()
        {
            tblOrderMeds = new HashSet<tblOrderMed>();
        }

        [Key]
        public int ORDER_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime ORDER_DATE { get; set; }

        [Required]
        [StringLength(50)]
        public string ORDER_STATUS { get; set; }

        [Required]
        [StringLength(50)]
        public string PAYMENT_MODE { get; set; }

        public int PATIENT_FID { get; set; }

        public int ADMIN_FID { get; set; }

        public virtual tblAdmin tblAdmin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOrderMed> tblOrderMeds { get; set; }

        public virtual tblPatient tblPatient { get; set; }
    }
}
