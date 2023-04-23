using DataLayer.Context;
using DataLayer.Repository;
using DataLayer.Services;
using DataLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace News.Controllers
{
    public class AccountController : Controller
    {
        MyNewsContext db=new MyNewsContext();
        ILoginRepository loginRepository;
        public AccountController()
        {
            loginRepository = new LoginRepository(db);
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public  ActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                if (loginRepository.IsExistUser(login.Username, login.Password))
                {

                    FormsAuthentication.SetAuthCookie(login.Username, login.Remeberme);
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError("Username", "کابری یافت نشد");
                }
            }
            return View(login);
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}