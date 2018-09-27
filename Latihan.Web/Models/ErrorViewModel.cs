using System;
using System.Collections.Generic;
using Latihan.Data;

namespace Latihan.Web.Models
{
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