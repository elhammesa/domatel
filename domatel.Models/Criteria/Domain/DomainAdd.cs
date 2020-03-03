using System;
using System.Collections.Generic;
using System.Text;

namespace domatel.Models.Criteria.Domain
{
   public class DomainAdd
    {
        

        public int BasePrice { get; set; }
        public int FinalPrice { get; set; }
        public int RemainTime { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Boolean isAvailable { get; set; }
        public string Url { get; set; }
        public Boolean HaveContent { get; set; }
        public string UserId { get; set; }
    }
}
