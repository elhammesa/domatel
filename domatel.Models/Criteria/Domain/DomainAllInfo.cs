using System;
using System.Collections.Generic;
using System.Text;

namespace domatel.Models.Criteria.Domain
{
   public class DomainAllInfo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool HaveContent{ get; set; }
    
        public int BasePrice { get; set; }
        public DateTime StartDate { get; set; }
        public string Province { get; set; }
        public string FullName { get; set; }
        public int NumberOfParticipant { get; set; }
    }
}
