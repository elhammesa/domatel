using System;
using System.Collections.Generic;
using System.Text;
using domatel.Models.Products.Enums;

namespace domatel.Models.Criteria.Phone
{
   public class PhoneInfo
    {
        public int Id { get; set; }
        public string PermanentNumber { get; set; }
     
        public int BasePrice { get; set; }
        public string Province { get; set; }
        public KindOfUse KindOfUse { get; set; }

    }
}
