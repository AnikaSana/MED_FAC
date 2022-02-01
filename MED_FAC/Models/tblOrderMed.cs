namespace MED_FAC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblOrderMed")]
    public partial class tblOrderMed
    {
        [Key]
        public int OrderMedicine_ID { get; set; }

        public int ORDER_QUANTITY { get; set; }

        public int MEDICINE_FID { get; set; }

        public int ORDER_FID { get; set; }

        public virtual tblMed tblMed { get; set; }

        public virtual tblOrder tblOrder { get; set; }
    }
}
