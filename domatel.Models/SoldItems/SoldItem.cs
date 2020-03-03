using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using domatel.Models.Products;
using domatel.Models.Users;

namespace domatel.Models.SoldItems
{
   public class SoldItem
    {
        public int SoldItemId { get; set; }
        public int FinalPrice { get; set; }
        public  User Users { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
