namespace DEMO_BANHANG.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public virtual DbSet<account> accounts { get; set; }
        public virtual DbSet<bill> bills { get; set; }
        public virtual DbSet<billdetail> billdetails { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<feedback> feedbacks { get; set; }
        public virtual DbSet<producer> producers { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTs { get; set; }

        public Model1()
            : base("name=Model1")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
