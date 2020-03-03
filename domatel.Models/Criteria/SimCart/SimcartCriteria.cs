using System;
using System.Collections.Generic;
using System.Text;

namespace domatel.Models.Criteria.SimCart
{
   public class SimcartCriteria
    {
        public int Id { get; set; }
        public int SimcartOperatorType { get; set; }
        public string Number { get; set; }
        public int KindOfUse { get; set; }

        public int Price { get; set; }

        
    }
}
