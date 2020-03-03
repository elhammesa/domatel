using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using domatel.Models.Bids;
using domatel.Models.Products;
using domatel.Models.SoldItems;
using Microsoft.AspNetCore.Identity;

namespace domatel.Models.Users
{
   public class User: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Jender { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDayDate { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public virtual string FullName => $"{FirstName} {LastName}";
        public string Address { get; set; }
        public string NationalCode { get; set; }
       
        public ICollection<Product> Products { get; set; }
        public ICollection<SoldItem> SoldItem { get; set; }
        public ICollection<Bid> Bids { get; set; }
       





    }
}
