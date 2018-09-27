using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Latihan.Web.Models;

using Latihan.Data;

namespace Latihan.Web.Controllers
{
    public class HomeController : Controller
    {
        private DataAccess da;

        public HomeController(DataAccess dataaccess)
        {
            this.da = dataaccess;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var users = da.GetUser();
            return View(users);
        }

        [HttpPost]
        public IActionResult Index(TabelUser tabelUser){
            var res= da.InsertUser(tabelUser);
            if(res>0)
                return RedirectToAction("Index");
            return View();
        }
        public IActionResult Roles()
        {
            ViewData["Message"] = "Your application description page.";
            var data = da.GetRoles();
            return View(data);
        }


        [HttpPost]
        public IActionResult Roles(TabelRole tabelRole)
        {
            ViewData["Message"] = "Roles";
            var res =  da.InsertRole(tabelRole);
            if(res>0)
                return RedirectToAction("Roles");
            return View();
        }

        public IActionResult UserRole()
        {
            ViewData["Message"] = "Your contact page.";
            FormUserRoleViewModel data = new FormUserRoleViewModel();

            data.userroles= da.GetUserRoles();
            data.users=da.GetUser();
            data.roles= da.GetRoles();
            return View(data);
        }

        [HttpPost]
        public IActionResult UserRole(TabelUserRole tabelUserRole)
        {
            ViewData["Message"] = "Your contact page.";
            var res = da.InsertUserRole(tabelUserRole);
            if(res>0)
                return RedirectToAction("UserRole");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
