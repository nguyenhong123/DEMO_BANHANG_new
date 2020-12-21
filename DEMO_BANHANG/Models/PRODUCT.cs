using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DEMO_BANHANG.Models
{
    public class PRODUCT
    {

        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        [Required]
        [StringLength(255)]
        public string author { get; set; }

        public int price { get; set; }

        public byte? discount { get; set; }

        [StringLength(255)]
        public string images { get; set; }

        public int? producerid { get; set; }

        public int? catID { get; set; }

        public string description { get; set; }

        public byte status { get; set; }

        public DateTime? created_at { get; set; }


        public virtual ICollection<billdetail> billdetails { get; set; }

        public virtual category category { get; set; }

        public virtual ICollection<feedback> feedbacks { get; set; }

        public virtual producer producer { get; set; }
    }
}