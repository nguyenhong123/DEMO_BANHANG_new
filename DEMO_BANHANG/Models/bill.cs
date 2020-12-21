using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DEMO_BANHANG.Models
{
    public class bill
    {
        public int id { get; set; }

        public int accountId { get; set; }

        public int total { get; set; }

        public int status { get; set; }

        [Column(TypeName = "date")]
        public DateTime created_at { get; set; }

        public DateTime update_at { get; set; }

        public virtual account account { get; set; }

        public virtual ICollection<billdetail> billdetails { get; set; }
    }
}