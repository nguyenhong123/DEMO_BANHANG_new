using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DEMO_BANHANG.Models
{
    public class feedback
    {
        public int id { get; set; }

        public int productid { get; set; }

        public int accountid { get; set; }

        [Required]
        public string comment { get; set; }

        [Column(TypeName = "date")]
        public DateTime created_at { get; set; }

        public DateTime update_at { get; set; }

        public virtual account account { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }
    }
}