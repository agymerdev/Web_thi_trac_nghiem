using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTracNghiem.Models;


namespace WebTracNghiem.Areas.admin.Controllers
{
    public class DefaultController : Controller
    {
        private DBEntities db = new DBEntities();
        [HttpGet]
        // GET: admin/Default
        public ActionResult Login()
        {
            //nếu session admin đã có giá trị thì khi đăng nhập tự động chuyển về aciton Index của controllor home
            if (Session["admin"] !=null)
            {
                return RedirectToAction("Index", "Home");

            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username,string password)
        {
            var usr = username;
            var pwd = password;
            var acc = db.Admins.SingleOrDefault(x=>x.TaiKhoan == usr && x.MatKhau == pwd);
            if (acc !=null)
            {
                //Đăng nhập thành công
                Session["admin"] = acc;
                return RedirectToAction("Index", "Home");
            }else
            {
                //đăng nhập thất bại
                return View();
            }    
            

        }
    }
}