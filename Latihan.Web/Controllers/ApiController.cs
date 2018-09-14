using System.Collections.Generic;
using Latihan.Data;
using Microsoft.AspNetCore.Mvc;

namespace Latihan.Web.Controllers{
    public class ApiController : Controller
    {
        public  IActionResult Roles(){
            DataAccess da = new DataAccess();
            IEnumerable<TabelRole> data = da.GetRoles();
            
            return Ok(data);
        }
    }


}