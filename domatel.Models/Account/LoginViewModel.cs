using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace domatel.Models.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "(*)")]
        [Display(Name = "ایمیل")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "کلمه‌ی عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "به‌خاطر سپاری کلمه‌ی عبور؟")]
        public bool RememberMe { get; set; }
    }
}
