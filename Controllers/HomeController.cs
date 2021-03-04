using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    { 
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult T_LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult T_LogIn(string TextBox_TID, string Password_TPassword)
        {
            //當用戶登入驗證通過時
            if (VaildateLogOn_T(TextBox_TID, Password_TPassword))
            {
                //執行將用戶登入到網站並授予存取權限
                LoginProcess_T(TextBox_TID, false);

                //移轉到指定動作與控制器檢視頁面
                return RedirectToAction("Home_T", "Teachers");
            }
            else
            {
                //設定模型驗證欄位狀態顯示失敗顯示訊息
                ModelState.AddModelError("VaildationMessge_TID", "您輸入的帳號密碼有誤，請重新輸入");
            }

            return View();
        }

        public ActionResult A_LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult A_LogIn(string TextBox_AID, string Password_APassword)
        {
            //當用戶登入驗證通過時
            if (VaildateLogOn_A(TextBox_AID, Password_APassword))
            {
                //執行將用戶登入到網站並授予存取權限
                LoginProcess_A(TextBox_AID, false);

                //移轉到指定動作與控制器檢視頁面
                return RedirectToAction("Index_Course", "Courses");
            }
            else
            {
                //設定模型驗證欄位狀態顯示失敗顯示訊息
                ModelState.AddModelError("VaildationMessge_AID", "您輸入的帳號密碼有誤，請重新輸入");
            }

            return View();
        }
         
        //用戶登入的驗證方法
        private bool VaildateLogOn_T(string strTID_Val, string strPassword_Val)
        {
            //宣告字串變數(用戶密碼)
            string strHashedPassword = strPassword_Val;

            //宣告與建構資料實體模型物件操作案例並自動釋放占用資源
            using (MoodleModel moodleModel = new MoodleModel())
            {
                Teacher objTeacher_Val = moodleModel.Teachers.Where(p => p.TID == strTID_Val && p.TPassword == strHashedPassword).FirstOrDefault();
                
                if(objTeacher_Val != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        //將用戶登入到網站並授予存取權限處理方法
        private void LoginProcess_T(string strT_Val, bool isRemeber_Val)
        {
            //登入前先清空所有Session資料
            Session.RemoveAll();

            //宣告與建構物件操作案例並初始化參數。(表單票證通行)
            FormsAuthenticationTicket objFormsAuthenticationTicket = new FormsAuthenticationTicket
            (
                1,      //版本
                strT_Val,   //你想要存放在User.Identy.Name 的值，通常是使用者帳號
                DateTime.Now, //核發日期
                DateTime.Now.AddMinutes(30), //到期日期30分鐘
                false, //將管理者登入的Cookie設定成Session Cookie(持續性)
                         //userdata 看你想存放甚麼，目前存放角色名稱(使用者專屬資料的類別)
                FormsAuthentication.FormsCookiePath  //Cookie路徑
            );


            //建立包含適用於HTTP Cookie 加密的表單驗證票證的字串
            string strEncryptTicket = FormsAuthentication.Encrypt(objFormsAuthenticationTicket);

            //將HTTP Cookie加密的表單驗證票證的字串存入Cookie裡面
            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, strEncryptTicket));
        }

        private bool VaildateLogOn_A(string strAID_Val, string strPassword_Val)
        {
            //宣告字串變數(用戶密碼)
            string strHashedPassword = strPassword_Val;

            //宣告與建構資料實體模型物件操作案例並自動釋放占用資源
            using (MoodleModel moodleModel = new MoodleModel())
            {
                Admin objAdmin_Val = moodleModel.Admins.Where(p => p.AID == strAID_Val && p.APassword == strHashedPassword).FirstOrDefault();

                if (objAdmin_Val != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void LoginProcess_A(string strA_Val, bool isRemeber_Val)
        {
            //登入前先清空所有Session資料
            Session.RemoveAll();

            //宣告與建構物件操作案例並初始化參數。(表單票證通行)
            FormsAuthenticationTicket objFormsAuthenticationTicket = new FormsAuthenticationTicket
            (
                1,      //版本
                strA_Val,   //你想要存放在User.Identy.Name 的值，通常是使用者帳號
                DateTime.Now, //核發日期
                DateTime.Now.AddMinutes(30), //到期日期30分鐘
                false, //將管理者登入的Cookie設定成Session Cookie(持續性)
                       //userdata 看你想存放甚麼，目前存放角色名稱(使用者專屬資料的類別)
                FormsAuthentication.FormsCookiePath  //Cookie路徑
            );


            //建立包含適用於HTTP Cookie 加密的表單驗證票證的字串
            string strEncryptTicket = FormsAuthentication.Encrypt(objFormsAuthenticationTicket);

            //將HTTP Cookie加密的表單驗證票證的字串存入Cookie裡面
            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, strEncryptTicket));
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