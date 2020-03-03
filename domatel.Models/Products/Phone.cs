using System;
using System.Collections.Generic;
using System.Text;
using domatel.Models.Products.Enums;

namespace domatel.Models.Products
{
  public class Phone:Product
    {
        public string PermanentNumber { get; set; }
        public KindOfUse KindOfUses { get; set; }


    }
}
