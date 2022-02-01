namespace MED_FAC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblApp")]
    public partial class tblApp
    {
        [Key]
        public int APPOINTMENT_ID { get; set; }

        public DateTime APPOINTMENT_DateTime { get; set; }

        public int PATIENT_FID { get; set; }

        public int SCHEDULE_FID { get; set; }

        public virtual tblPatient tblPatient { get; set; }

        public virtual tblSchedule tblSchedule { get; set; }
    }
}
