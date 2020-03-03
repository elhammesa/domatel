using System;
using System.Collections.Generic;
using System.Text;

namespace domatel.Models.Account
{
    public class ResetPassword
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
