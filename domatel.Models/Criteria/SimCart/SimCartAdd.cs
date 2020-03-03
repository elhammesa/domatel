using System;
using System.Collections.Generic;
using System.Text;
using domatel.Models.Products.Enums;

namespace domatel.Models.Criteria.SimCart
{
   public  class SimCartAdd
    {
       

        public int BasePrice { get; set; }
        public int FinalPrice { get; set; }
        public int RemainTime { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Boolean IsAvailable { get; set; }
        public string Number { get; set; }
        public SimcartOperatorType OperatorType { get; set; }
        public SimcartType SimcartType { get; set; }
        public KindOfUse KindOfUse { get; set; }
        public RoundType RoundType { get; set; }
        public string UserId { get; set; }
    }
}
