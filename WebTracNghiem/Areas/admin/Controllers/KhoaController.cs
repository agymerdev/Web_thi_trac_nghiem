using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebTracNghiem.Models;

namespace WebTracNghiem.Areas.admin.Controllers
{
    public class KhoaController : BaseController
    {
        private DBEntities db = new DBEntities();

        // GET: admin/Khoa
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult DsKhoa()
        {
            try
            {
                var dsKhoa= (from k in db.Khoas.Where(x=>x.DaXoa !=1)//chỉ lấy những khoa chưa bị xóa
                            select new
                            {
                                Id=k.Id,
                                TenKhoa = k.TenKhoa,
                                Meta=k.Meta
                            }).ToList();
                return Json(new {code = 200,dsKhoa=dsKhoa, msg="Lấy danh sách khoa thành công"},JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { code = 500, msg = "Lấy danh sách khoa thất bại: " + ex.Message },JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult AddKhoa(string tenKhoa,string meta)
        {
            try
            {
                var k = new Khoa();
                k.TenKhoa=tenKhoa;
                k.Meta = meta;

                db.Khoas.Add(k);
                db.SaveChanges();

                return Json(new { code = 200, msg = "Thêm mới khoa thành công!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { code = 500, msg = "Thêm mưới khoa thất bại.Lỗi: " } + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult ChiTiet(int id)
        {
            try
            {
                var k = db.Khoas.SingleOrDefault(x => x.Id == id);
                return Json(new { code = 200, K = k, msg = "Lấy thông tin chi tiết của khoa thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { code = 500, msg = "Lấy thông tin chi tiết của khoa thất bại"+ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }
    }
}
