using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using domatel.Models.Bids;
using domatel.Models.Users;
using domatel.Models.SoldItems;
namespace domatel.Models.Products
{
   public class Product

    {
        public int Id { get; set; }

        public int BasePrice { get; set; }
        public int FinalPrice { get; set; }
        public int RemainTime { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Boolean sAvailable { get; set; }
        public User Owner { get; set; }

        public ICollection<Bid> Bid { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public SoldItem SoldItems { get; set; }



    }
}
