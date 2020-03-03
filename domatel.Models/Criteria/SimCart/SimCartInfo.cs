using System;
using System.Collections.Generic;
using System.Text;
using domatel.Models.Products.Enums;

namespace domatel.Models.Criteria.SimCart
{
   public class SimCartInfo
    {
        public int Id{ get; set; }
        public SimcartOperatorType OperatorType { get; set; }
        public string Number { get; set; }
        public int BasePrice { get; set; }
        public KindOfUse KindOfUse { get; set; }
        public SimcartType SimcartType { get; set; }
        public string Province { get; set; }
        public RoundType RoundType { get; set; }
    }
}
