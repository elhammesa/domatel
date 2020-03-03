using System;
using System.Collections.Generic;
using System.Text;
using domatel.Models;
using domatel.Models.Products.Enums;

namespace domatel.Models.Products
{
  public  class SimCart:Product
    {
        public string Number { get; set; }
        public SimcartOperatorType OperatorType { get; set; }
        public SimcartType SimcartType { get; set; }
        public KindOfUse KindOfUse { get; set; }
        public RoundType RoundType { get; set; }

    }
}
