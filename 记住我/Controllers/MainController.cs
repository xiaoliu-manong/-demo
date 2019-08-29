using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 记住我.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string account,string password,string verifcode)
        {
            if(verifcode!="1234")
            {
                return Json("error");
            }
            if(account!="admin"||password!="123456")
            {
                return Json("error");
            }
            CookiesHelper.AddCookie("ua", account);
            CookiesHelper.AddCookie("up", password);
            return Json("OK");
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}