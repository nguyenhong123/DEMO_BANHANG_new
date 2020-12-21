using DEMO_BANHANG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
//using DEMO_BANHANG.Models;

namespace DEMO_BANHANG.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        public ActionResult Index( string Area)
        {
            return View(db.PRODUCTs);
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var  f_password = GETMD5(password);
                var data = db.accounts.Where(s => s.email.Equals(email) && s.password.Equals(f_password)).ToList();
                if (data != null)
                {
                    Session["IdAccount"] = data.FirstOrDefault().id;
                    Session["NameAccount"] = data.FirstOrDefault().name;
                    Session["role"] = data.FirstOrDefault().role;
                    var checkAdmin = data.FirstOrDefault().role;
                    if(checkAdmin == "customer")
                    {
                        return RedirectToAction("Trangchu"); // Trang nguoi dung
                        
                        
                    }
                    else if(checkAdmin == "")
                    {
                        return RedirectToAction("Index"); // Trang admin
                    }   
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }        
        }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
            public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Register(account acc)
        {
            if (ModelState.IsValid)
            {
                var checkemail = db.accounts.FirstOrDefault(m => m.email == acc.email);
                if (checkemail == null)
                {
                    acc.password = GETMD5(acc.password);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.accounts.Add(new account {
                        id = acc.id,
                        name = acc.name,
                        email = acc.email,
                        password = acc.password,
                        address = acc.address,
                        phone = acc.phone,
                        role = "customer",
                    });
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.emailerror = "Email already exists";
                    return View();

                }
            }
            return View();

        }
        public static string GETMD5(string pass)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(pass);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;

        }
        public ActionResult Trangchu()
        {
            ViewBag.SanPhams = db.PRODUCTs.ToList();
            return View();
        }
    
    }
}