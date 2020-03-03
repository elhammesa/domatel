using System;
using System.Collections.Generic;
using System.Text;

namespace domatel.Models.Criteria.Phone
{
    public class PhoneAllInfo
    {
        public int Id { get; set; }
        public string PermanentNumber { get; set; }
      

        public int BasePrice { get; set; }
        public DateTime StartDate { get; set; }
        public string Province { get; set; }
        public string FullName { get; set; }
        public int NumberOfParticipant { get; set; }
    }
}
