using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using domatel.Models.Products;
using domatel.Models.Users;

namespace domatel.Models.Bids
{
    public class Bid
    {
        public int BidId { get; set; }

        public DateTime CreateDateTime { get; set; }

        public   User User { get; set; }
      
        [ForeignKey("User")]
        public string UserId { get; set; }

        public int NumberOfParticipant { get; set; }

        public virtual Product Product { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int OfferPrice { get; set; }
       
       

    }
}
