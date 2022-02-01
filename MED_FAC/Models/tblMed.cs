namespace MED_FAC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblMed")]
    public partial class tblMed
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMed()
        {
            tblOrderMeds = new HashSet<tblOrderMed>();
        }

        [Key]
        public int MEDICINE_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string MEDICINE_NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string MEDICINE_BRAND { get; set; }

        //[Required]
        public string MEDICINE_IMAGE { get; set; }

        [Required]
        [StringLength(50)]
        public string MADICINE_WEIGHT { get; set; }

        [Required]
        [StringLength(50)]
        public string MEDICINE_PRICE { get; set; }

        [Required]
        [StringLength(50)]
        public string MEDICINE_DETAILS { get; set; }

        public int OrderMed_FID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOrderMed> tblOrderMeds { get; set; }
    }
}
