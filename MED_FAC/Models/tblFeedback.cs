namespace MED_FAC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblFeedback")]
    public partial class tblFeedback
    {
        [Key]
        public int FEEDBACK_ID { get; set; }

        [Required]
        public string FEEDBACK_DESCRIPTION { get; set; }

        [Column(TypeName = "date")]
        public DateTime FEEDBACK_DATE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal FEEDBACK_RATING { get; set; }

        public int PATIENT_FID { get; set; }

        public virtual tblPatient tblPatient { get; set; }
    }
}
