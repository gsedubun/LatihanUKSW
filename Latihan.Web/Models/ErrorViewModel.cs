using System;
using System.Collections.Generic;
using Latihan.Data;

namespace Latihan.Web.Models
{
    public class LoginViewModel
    {
        private string username;
        public string UserName
        {
            get { return username;}
            set { username = value;}
        }
        

        private string password;
        public string Password
        {
            get { return password;}
            set { password = value;}
        }
        public bool RememberMe { get; set; }
        
    }
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
    public class FormUserRoleViewModel
    {
        public IEnumerable<TabelUser> users { get; set; }        
        public IEnumerable<TabelRole> roles { get; set; }        
        public IEnumerable<VWUserRole> userroles { get; set; }        


    }
}