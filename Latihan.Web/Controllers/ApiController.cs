using System.Collections.Generic;
using Latihan.Data;
using Microsoft.AspNetCore.Mvc;

namespace Latihan.Web.Controllers{
    [Route("api")]
    public class ApiController : Controller
    {
        private DataAccess da;

        public ApiController(DataAccess dataaccess)
        {
            this.da= dataaccess;
        }
        [Route("roles")]
        public  IActionResult Roles(){
            IEnumerable<TabelRole> data = da.GetRoles();
            return Ok(data);
        }

        [Route("users")]
        public IActionResult Users(){
            IEnumerable<TabelUser> data = da.GetUser();
            return Ok(data);
        }
        
        [Route("deleteuser")]
        public IActionResult DeleteUser(int user_id){
            int deleted = da.DeleteUser(user_id);
            return Ok(deleted);
        }
    }


}