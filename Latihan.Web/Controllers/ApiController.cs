using System.Collections.Generic;
using Latihan.Data;
using Microsoft.AspNetCore.Mvc;

namespace Latihan.Web.Controllers{
    [Route("api")]
    public class ApiController : Controller
    {
        [Route("roles")]
        public  IActionResult Roles(){
            DataAccess da = new DataAccess();
            IEnumerable<TabelRole> data = da.GetRoles();
            return Ok(data);
        }

        [Route("users")]
        public IActionResult Users(){
            DataAccess da = new DataAccess();
            IEnumerable<TabelUser> data = da.GetUser();
            return Ok(data);
        }
        
        [Route("deleteuser")]
        public IActionResult DeleteUser(int user_id){
            DataAccess da  = new DataAccess();
            int deleted = da.DeleteUser(user_id);
            return Ok(deleted);
        }
    }


}