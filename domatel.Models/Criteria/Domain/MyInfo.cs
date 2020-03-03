using System;
using System.Collections.Generic;
using System.Text;

namespace domatel.Models.Criteria.Domain
{
   public class MyInfo
    {
        public string Url { get; set; }
        public int BasePrice { get; set; }
        public int FinalPrice { get; set; }
        public Boolean Available { get; set; }
        public int RemainTime { get; set; }
        public int OfferPrice { get; set; }
        public string Number { get; set; }
        public string PermanentNumber { get; set; }

    }
}
