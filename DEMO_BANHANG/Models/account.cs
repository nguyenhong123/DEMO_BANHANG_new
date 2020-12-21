using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DEMO_BANHANG.Models
{
    public class account
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        [Required]
        [StringLength(255)]
        public string email { get; set; }

        [Required]
        [StringLength(255)]
        public string password { get; set; }

        [Required]
        [StringLength(255)]
        public string address { get; set; }

        [Required]
        [StringLength(15)]
        public string phone { get; set; }

        public string role { get; set; }

        public virtual ICollection<bill> bills { get; set; }


        public virtual ICollection<feedback> feedbacks { get; set; }
    }
}