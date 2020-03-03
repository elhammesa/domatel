using System;
using System.Collections.Generic;
using System.Text;

namespace domatel.Models.Criteria.Domain
{
   public class DomainInfo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public Boolean HaveContent { get; set; }
        public int BasePrice { get; set; }
        public string Province { get; set; }


    }
}
