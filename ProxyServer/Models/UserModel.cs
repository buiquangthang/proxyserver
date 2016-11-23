using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProxyMVCv1.Models
{
    public class UserModel
    {
        [DisplayName("User ID")]
        public int Id { get; set; }

        [DisplayName("User name")]
        public string Username { get; set; }

        public string Password { get; set; }
    }
}