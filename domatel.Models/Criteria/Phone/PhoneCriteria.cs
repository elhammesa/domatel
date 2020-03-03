using System;
using System.Collections.Generic;
using System.Text;

namespace domatel.Models.Criteria.Phone
{
   public class PhoneCriteria
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int KindOfUse { get; set; }

        public int Price { get; set; }
    }
}
