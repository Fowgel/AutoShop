using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoWebShop.Models
{
    public class AccountModel
    {
        public Guid AccountId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public DateTime? DayCreated { get; set; }
    }
    //public class LoginModel
    //{
    //    public string Email { get; set; }
    //    public string Password { get; set; }
    //    public bool RememberMe { get; set; }

    //}
    //public class ExternalLoginModel
    //{
    //    public string ReturnUrl { get; set; }
    //}
}