using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DataContract;
using MyLove.Models;
using Servers;
using Servers.Interface;
using log4net;
namespace MyLove.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ILog Logger;
        public LoginController()
        {
            Logger = LogManager.GetLogger(this.GetType());
        }

        public ActionResult Index()
        {
            var user = Session["userId"] ?? "";
            if (user.ToString() != "")
                return Redirect("~/home/home");
            return View("LoginPage");
        }

        [HttpPost]
        public ActionResult LogIn(LoginInfo loginInfo)
        {
            List<DataElement> de;
            int userId;
            Logger.Info("LoginController:username="+loginInfo.username+" password="+loginInfo.password);
            if (!Validate(loginInfo, out de))
            {
                Logger.Info("LoginController:Fail validation.");
                return RedirectToAction("Index");
            }
            if (!LoginAccount(de,out userId))
            {
                Logger.Info("LoginController:Fail LoginAccount");
                return RedirectToAction("Index");
            }

            
            Session["userId"] = userId;
            Logger.Info("LoginController:Success Login "+userId);
            return RedirectToAction("Index");
        }

        public bool Validate(LoginInfo li,out List<DataElement> de)
        {
            Logger.Info("LoginController:");
            de=new List<DataElement>();
            if (string.IsNullOrEmpty(li.password)||string.IsNullOrEmpty(li.username))
            {
                return false;
            }
            de.Add(new DataElement(){Name = "username",Value = li.username});
            de.Add(new DataElement() { Name = "password", Value = li.password });
            return true;
        }

        public bool LoginAccount(List<DataElement> de ,out int userId)
        {
            ;
            ILoginServers loginServers=new LoginServers();
            return loginServers.LoginAccount(de, out userId);
        }
    }
}
