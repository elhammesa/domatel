using System;
using System.Collections.Generic;
using System.Text;

namespace domatel.Models.Criteria.SimCart
{
   public class SimcartAllInfo
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int OperatorType { get; set; }
        public int SimcartType { get; set; }
        public int KindOfUse { get; set; }
        public int RoundType { get; set; }
        public int BasePrice { get; set; }
        public DateTime StartDate { get; set; }
        public string Province { get; set; }
        public  string FullName { get; set; }
        public int NumberOfParticipant { get; set; }
    }
}
