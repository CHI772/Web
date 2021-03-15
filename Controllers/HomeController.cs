using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web.Models;
using Web.ViewModel;
using System.Security.Claims;

namespace Web.Controllers
{
    public class HomeController : Controller
    { 
        private MoodleModel db;
        public HomeController()
        {
            db = new MoodleModel();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult T_LogIn()
        {
            return View();
        }
        
        public ActionResult A_LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult T_Login(T_LoginViewModel login)
        {
            var result = db.Teachers.Where(x => x.TID == login.TID && x.TPassword == login.TPassword).FirstOrDefault(); //驗證
            if (result != null) //資料庫有資料(這個人)
            {
                //授權

                // 建立使用者的登入資訊
                ClaimsIdentity identity = new ClaimsIdentity(new[] {
                    //加入使用者的相關資訊
                    new Claim(ClaimTypes.Name, result.TName),
                    new Claim("TID",result.TID)
                }, "Cookies");

                Request.GetOwinContext().Authentication.SignIn(identity); //授權(登入)

                return RedirectToAction("Home_T", "Teachers");
            }
            else
            {
                ModelState.AddModelError("", "輸入的帳密可能有誤或是沒有註冊");
                return RedirectToAction("T_Login", "Home");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult A_Login(A_LoginViewModel alogin)
        {
            var result = db.Admins.Where(x => x.AID == alogin.AID && x.APassword == alogin.APassword).FirstOrDefault(); //驗證
            if (result != null) //資料庫有資料(這個人)
            {
                //授權

                // 建立使用者的登入資訊
                ClaimsIdentity identity = new ClaimsIdentity(new[] {
                    //加入使用者的相關資訊
                    new Claim(ClaimTypes.Name, result.AName),
                    new Claim("AID",result.AID)
                }, "Cookies");

                Request.GetOwinContext().Authentication.SignIn(identity); //授權(登入)

                return RedirectToAction("Home_A", "Admins");
            }
            else
            {
                ModelState.AddModelError("", "輸入的帳密可能有誤或是沒有註冊");
                return RedirectToAction("A_Login", "Home");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}