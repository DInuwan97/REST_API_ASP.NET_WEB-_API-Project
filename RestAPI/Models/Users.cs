using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class Users
    {
        public int UserID { get; set; }
        public String UserName { get; set; }
        public String UserEmail { get; set; }
        public String UserMobile { get; set; }
        public String UserDepartment { get; set; }
        public String UserType { get; set; }
        public String Password { get; set; }
        public String ConfirmPassword { get; set; }
        public String SecretKey { get; set; }
        public String Validation { get; set; }

    
    }
}