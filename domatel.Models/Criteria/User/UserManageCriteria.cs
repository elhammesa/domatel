using System;
using System.Collections.Generic;
using System.Text;

namespace domatel.Models.Criteria.User
{
    public class UserManageCriteria 
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string PresentCode { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string RoleId { get; set; }
        public DateTime? FromDateTime { get; set; }
        public DateTime? TillDateTime { get; set; }
        public int Status { get; set; }
        public List<string> UsersId { get; set; }
    }
}
