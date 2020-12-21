using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DEMO_BANHANG.Models
{
    public class billdetail
    {
        public int id { get; set; }

        public int billID { get; set; }

        public int productId { get; set; }

        public int quantity { get; set; }

        public int price { get; set; }

        public byte? discount { get; set; }

        public int sum_price { get; set; }

        [Column(TypeName = "date")]
        public DateTime created_at { get; set; }

        public DateTime update_at { get; set; }

        public virtual bill bill { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }
    }
}