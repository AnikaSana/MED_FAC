using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MED_FAC.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<tblAdmin> tblAdmins { get; set; }
        public virtual DbSet<tblApp> tblApps { get; set; }
        public virtual DbSet<tblDept> tblDepts { get; set; }
        public virtual DbSet<tblDoctor> tblDoctors { get; set; }
        public virtual DbSet<tblFeedback> tblFeedbacks { get; set; }
        public virtual DbSet<tblMed> tblMeds { get; set; }
        public virtual DbSet<tblOrder> tblOrders { get; set; }
        public virtual DbSet<tblOrderMed> tblOrderMeds { get; set; }
        public virtual DbSet<tblPatient> tblPatients { get; set; }
        public virtual DbSet<tblSchedule> tblSchedules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblAdmin>()
                .Property(e => e.ADMIN_NAME)
                .IsFixedLength();

            modelBuilder.Entity<tblAdmin>()
                .Property(e => e.ADMIN_EMAIL)
                .IsFixedLength();

            modelBuilder.Entity<tblAdmin>()
                .Property(e => e.ADMIN_PASSWORD)
                .IsFixedLength();

            modelBuilder.Entity<tblAdmin>()
                .Property(e => e.ADMIN_CONTACT)
                .IsFixedLength();

            modelBuilder.Entity<tblAdmin>()
                .HasMany(e => e.tblOrders)
                .WithRequired(e => e.tblAdmin)
                .HasForeignKey(e => e.ADMIN_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblDept>()
                .HasMany(e => e.tblDoctors)
                .WithRequired(e => e.tblDept)
                .HasForeignKey(e => e.DEPARTMENT_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblDoctor>()
                .HasMany(e => e.tblSchedules)
                .WithRequired(e => e.tblDoctor)
                .HasForeignKey(e => e.DOCTOR_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblFeedback>()
                .Property(e => e.FEEDBACK_RATING)
                .HasPrecision(18, 1);

            modelBuilder.Entity<tblMed>()
                .HasMany(e => e.tblOrderMeds)
                .WithRequired(e => e.tblMed)
                .HasForeignKey(e => e.MEDICINE_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblOrder>()
                .HasMany(e => e.tblOrderMeds)
                .WithRequired(e => e.tblOrder)
                .HasForeignKey(e => e.ORDER_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblPatient>()
                .HasMany(e => e.tblApps)
                .WithRequired(e => e.tblPatient)
                .HasForeignKey(e => e.PATIENT_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblPatient>()
                .HasMany(e => e.tblFeedbacks)
                .WithRequired(e => e.tblPatient)
                .HasForeignKey(e => e.PATIENT_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblPatient>()
                .HasMany(e => e.tblOrders)
                .WithRequired(e => e.tblPatient)
                .HasForeignKey(e => e.PATIENT_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblSchedule>()
                .HasMany(e => e.tblApps)
                .WithRequired(e => e.tblSchedule)
                .HasForeignKey(e => e.SCHEDULE_FID)
                .WillCascadeOnDelete(false);
        }
    }
}
